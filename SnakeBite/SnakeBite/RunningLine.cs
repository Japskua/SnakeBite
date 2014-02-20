using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace SnakeBite
{
    
    class RunningLine
    {
        private string TEXT;
        private float _Scrolling_Speed;
        private List<Letter> _Letters;
        private int _current_chapter = 0;
        private Game _parent;
        private bool _running = false;
        private bool _increased = false;
        private ParticleSystem _Stars;
        public void LoadStory(int _chapter)
        {
            
           
            _Scrolling_Speed = 8;
            _current_chapter = new Random().Next(0, LoadHelper.Chaptures.Count);

            Console.WriteLine("LOADING STORY");
            Console.WriteLine(LoadHelper.Chaptures.Count);

            Console.WriteLine(_current_chapter);

            TEXT = LoadHelper.Chaptures[_current_chapter];
            Console.WriteLine(TEXT);
            TEXT = TEXT.ToLower();
            _Letters.Clear();
            for (int i = 0; i < TEXT.Length; i++)
            {
                _Letters.Add(new Letter(TEXT[i], new Vector2(Game1._screen_width*1.4f + 90 * i, 15)));
            }
            _running = true;
        }
        public RunningLine(Game _new_parent)
        {
            _Letters = new List<Letter>();
            //LoadStory(Game1._Chapter);
            _parent = _new_parent;
            _Stars = new ParticleSystem(LoadHelper.Textures[TextureEnum.star_small], 300, 500, true, true);
            
        }
        private void RemoveLetter(GameTime gameTime)
        {

            _Stars.Start(gameTime, new Vector2(_Letters[0].GetX() + 50, 75), 25);
            _Letters.RemoveAt(0); _increased = false;
            LoadHelper.Sounds[SoundEnum.letter_down].Play();
            _Scrolling_Speed = _Scrolling_Speed * 1.01f;
        }
        public void Update(GameTime gameTime)
        {
            _Letters.ForEach(delegate(Letter _temp)
            {
                if (_Letters[0].GetX() > Game1._screen_width / 2 - LoadHelper.Textures[TextureEnum.dock].Width / 2) 
                _temp.Update(gameTime, _Scrolling_Speed);
            });
            //LETTER OUT OF DOCK
            if (_Letters.Count > 0)
            {
                if (_Stars != null) _Stars.Update(gameTime, new Vector2(0, 0), Color.White, new Vector2(0, 0));
                if (_Letters[0].GetX() < Game1._screen_width / 2 - LoadHelper.Textures[TextureEnum.dock].Width / 2 + 5)
                {
                   _parent.MoveSnake();
                }
            }
            KeyboardState keyState = Keyboard.GetState();


            if (_Letters.Count > 0)
            {
                if (_Scrolling_Speed > 14) _Scrolling_Speed = 14;
                if (_running == true && _increased == false)
                {
                    if (_Letters[0].GetX() > Game1._screen_width / 2 + LoadHelper.Textures[TextureEnum.dock].Width / 2)
                    {
                        _Scrolling_Speed = _Scrolling_Speed * 1.15f;
                       
                        _increased = true;
                    }
                }
                if (_Letters[0].GetX() < Game1._screen_width / 2 + LoadHelper.Textures[TextureEnum.dock].Width / 2)
                {
                    
                    switch (_Letters[0].GetLetter())
                    {
                        case 'a': if (keyState.IsKeyDown(Keys.A)) RemoveLetter(gameTime); break;
                        case 'b': if (keyState.IsKeyDown(Keys.B)) RemoveLetter(gameTime); break;
                        case 'c': if (keyState.IsKeyDown(Keys.C)) RemoveLetter(gameTime); break;
                        case 'd': if (keyState.IsKeyDown(Keys.D)) RemoveLetter(gameTime); break;
                        case 'e': if (keyState.IsKeyDown(Keys.E)) RemoveLetter(gameTime); break;
                        case 'f': if (keyState.IsKeyDown(Keys.F)) RemoveLetter(gameTime); break;
                        case 'g': if (keyState.IsKeyDown(Keys.G)) RemoveLetter(gameTime); break;
                        case 'h': if (keyState.IsKeyDown(Keys.H)) RemoveLetter(gameTime); break;
                        case 'i': if (keyState.IsKeyDown(Keys.I)) RemoveLetter(gameTime); break;
                        case 'j': if (keyState.IsKeyDown(Keys.J)) RemoveLetter(gameTime); break;
                        case 'k': if (keyState.IsKeyDown(Keys.K)) RemoveLetter(gameTime); break;
                        case 'l': if (keyState.IsKeyDown(Keys.L)) RemoveLetter(gameTime); break;
                        case 'm': if (keyState.IsKeyDown(Keys.M)) RemoveLetter(gameTime); break;
                        case 'n': if (keyState.IsKeyDown(Keys.N)) RemoveLetter(gameTime); break;
                        case 'o': if (keyState.IsKeyDown(Keys.O)) RemoveLetter(gameTime); break;
                        case 'p': if (keyState.IsKeyDown(Keys.P)) RemoveLetter(gameTime); break;
                        case 'q': if (keyState.IsKeyDown(Keys.Q)) RemoveLetter(gameTime); break;
                        case 'r': if (keyState.IsKeyDown(Keys.R)) RemoveLetter(gameTime); break;
                        case 's': if (keyState.IsKeyDown(Keys.S)) RemoveLetter(gameTime); break;
                        case 't': if (keyState.IsKeyDown(Keys.T)) RemoveLetter(gameTime); break;
                        case 'u': if (keyState.IsKeyDown(Keys.U)) RemoveLetter(gameTime); break;
                        case 'v': if (keyState.IsKeyDown(Keys.V)) RemoveLetter(gameTime); break;
                        case 'w': if (keyState.IsKeyDown(Keys.W)) RemoveLetter(gameTime); break;
                        case 'x': if (keyState.IsKeyDown(Keys.X)) RemoveLetter(gameTime); break;
                        case 'y': if (keyState.IsKeyDown(Keys.Y)) RemoveLetter(gameTime); break;
                        case 'z': if (keyState.IsKeyDown(Keys.Z)) RemoveLetter(gameTime); break;
                        case ' ': if (keyState.IsKeyDown(Keys.Space)) RemoveLetter(gameTime); break;
                        case '.': if (keyState.IsKeyDown(Keys.OemPeriod)) RemoveLetter(gameTime); break;
                        case ',': if (keyState.IsKeyDown(Keys.OemComma)) RemoveLetter(gameTime); break;
                        //case '!': if (keyState.IsKeyDown(Keys.A)) _Letters.RemoveAt(0);_increased = false; break;
                        case '?': if (keyState.IsKeyDown(Keys.OemQuestion)) RemoveLetter(gameTime); break;
                    }
                }

            }
            if (_running == true && _Letters.Count == 0)
            {
                Console.WriteLine("TEXT IS OVER HERE IS OVER");
                _parent.TextOver(gameTime);
                _running = false;

                LoadHelper.Chaptures.RemoveAt(_current_chapter);
            }
            
        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_Letters.Count > 0)
            {
                if (_Stars != null) _Stars.Draw(spriteBatch);
                _Letters.ForEach(delegate(Letter _temp)
                {
                    _temp.Draw(spriteBatch);
                });
            }
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.dock], new Rectangle(Game1._screen_width / 2 - LoadHelper.Textures[TextureEnum.dock].Width/2, 0, LoadHelper.Textures[TextureEnum.dock].Width, LoadHelper.Textures[TextureEnum.dock].Height), Color.White);
        }
    }
}
