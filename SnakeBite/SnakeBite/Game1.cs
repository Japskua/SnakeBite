using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SnakeBite
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static SoundEffectInstance sound_bg;
        SoundEffect music;

        private TimeSpan _outro_timestamp;
       //private static TouchDebug _TouchDebug;
        public static int _screen_width;
        public static int _screen_height;
        public static int _Chapter = 1;

        private static TouchDebug _TouchDebug;
        private Intro _Intro;

        private Outro _Outro;
        private Menu _Menu;
        private static Game _Game;
        private int _intro_delay = 6;
        public enum States
        {
            Intro,
            Outro,
            Menu,
            Game,
            Closing,
            ChapterFinnished,
            Over,
            BirdEaten
        }
        public static States GameState = States.Intro;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _TouchDebug = new TouchDebug();
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            //_TouchDebug = new TouchDebug();
            music = Content.Load<SoundEffect>("SOUNDS\\birdies_bg");
            sound_bg = music.CreateInstance();
            sound_bg.IsLooped = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 
        public static void SetTouch(Vector2 _vector2)
        {
            _TouchDebug.SetTouch(_vector2);
        }

        public static void ChapterComplete()
        {
            Console.WriteLine("Checking chapter coutns");
            if (LoadHelper.Chaptures.Count == 0) GameState = States.Over;
            else GameState = States.ChapterFinnished;
        }
       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //TouchPanel.EnabledGestures = GestureType.Tap;

            //TouchPanel.EnabledGestures = GestureType.Tap;
            this.IsMouseVisible = true;

            _screen_height = graphics.PreferredBackBufferHeight;
            _screen_width = graphics.PreferredBackBufferWidth;
            base.Initialize();

            _Intro = new Intro();
            _Menu = new Menu();
            _Menu.SetChapter(_Chapter);
            _Game = new Game();
            _Outro = new Outro();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadHelper.Load(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            sound_bg.Play();
            // TODO: Add your update logic here

            base.Update(gameTime);
            switch (GameState)
            {
                case States.Intro:
                    _Intro.Update(gameTime);
                    if ((float)gameTime.TotalGameTime.Seconds > _intro_delay) GameState = States.Menu;
                    break;
                case States.Over:
                    _outro_timestamp = gameTime.TotalGameTime;
                    GameState = States.Outro;
                    break;
                case States.Outro:
                    if (4 < (gameTime.TotalGameTime.Seconds - _outro_timestamp.Seconds))
                    {
                        Console.WriteLine("EXITING");
                        this.Exit();
                    } 
                    break;
                case States.Game:
                    if (_Game != null)
                        _Game.Update(gameTime);
                    else _Game = new Game();
                    break;
                case States.Menu:
                    _Menu.Update(gameTime);
                    break;
                case States.ChapterFinnished:
                    _Chapter++;
                    if (LoadHelper.Chaptures.Count == 0) _Chapter = 1;
                    _Menu.SetChapter(_Chapter);
                    _Game.SetChapter(_Chapter);
                    GameState = States.Menu;
                    break;
                case States.BirdEaten:
                    _Menu.SetChapter(_Chapter);
                    _Game.SetChapter(_Chapter);
                    GameState = States.Menu;
                    break;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        ///
        public static void StartChapter()
        {
            _Game.SetChapter(_Chapter);

            GameState = States.Game;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
           //bg
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.bg], new Rectangle(0, 0, LoadHelper.Textures[TextureEnum.bg].Width, LoadHelper.Textures[TextureEnum.bg].Height), Color.White);
             switch (GameState)
            {
                case States.Intro:
                    _Intro.Draw(spriteBatch);
                    break;
                case States.Outro:
                    _Outro.Draw(spriteBatch);
                    break;
                case States.Game:
                     if (_Game != null)
                    _Game.Draw(spriteBatch);
                    break;
                case States.Menu:
                    _Menu.Draw(spriteBatch);
                    break;
            }
            _TouchDebug.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
