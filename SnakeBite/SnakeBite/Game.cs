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


namespace SnakeBite
{

    class Game
    {
        private Texture2D _fanfare_left_one, _fanfare_left_two, _fanfare_right_one, _fanfare_right_two;
        private Vector2 _fanfare_position_left, _fanfare_position_right;
        private Texture2D _texture_Chapter;
        private Texture2D _texture_Chapter_id_one, _texture_Chapter_id_two;
        private float _title_height;
        private float _rotation = 0;
        private float _rotation_rate = 0.05f;
        private Texture2D _texture;
        private Vector2 _center;
        private Snake _Snake;
        private Bird _Bird;
        private RunningLine _RunningLine;
        private bool _bird_dead = false;
        private ParticleSystem _Blood, _Fanfare, _Puff;
        private TimeSpan _bird_dead_timestamp;
        private Color _chapter_color;
        private bool _Puff_started;
        private TimeSpan _closing_timestamp;
        private bool _done = false;
        public void MoveSnake()
        {
            Console.WriteLine("MOVING SNAKE");
            _Snake.Move();
        }

        public void SetChapter(int _new_chapter)
        {
            _done = false;
            _bird_dead = false;
            _Snake.Reset();
            _RunningLine.LoadStory(_new_chapter);
            _texture_Chapter = LoadHelper.Textures[TextureEnum.chapter];
            _title_height = 220;
            _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_0];
            switch (_new_chapter%10)
            {
                case 0: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_0]; break;
                case 1: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_1]; break;
                case 2: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_2]; break;
                case 3: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_3]; break;
                case 4: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_4]; break;
                case 5: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_5]; break;
                case 6: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_6]; break;
                case 7: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_7]; break;
                case 8: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_8]; break;
                case 9: _texture_Chapter_id_one = LoadHelper.Numbers[NumberEnum.num_9]; break;

            }
            if (_new_chapter > 10)
            {
                switch ((_new_chapter - (_new_chapter % 10))/10)
                {
                    case 0: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_0]; break;
                    case 1: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_1]; break;
                    case 2: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_2]; break;
                    case 3: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_3]; break;
                    case 4: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_4]; break;
                    case 5: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_5]; break;
                    case 6: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_6]; break;
                    case 7: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_7]; break;
                    case 8: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_8]; break;
                    case 9: _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_9]; break;

                }
            }


            
            _chapter_color = Color.White;
            _Puff_started = false;
            _fanfare_position_left = new Vector2(-60, 150);
            _fanfare_position_right = new Vector2(Game1._screen_width - _fanfare_position_left.X,450);
            
        }

        public Game()
        {
           
            _texture = LoadHelper.Textures[TextureEnum.snake_body];
            _center = new Vector2(_texture.Width / 2, _texture.Height / 2);
            _Bird = new Bird(new Vector2(750, 500), -0.78f);

            _Snake = new Snake(new Vector2(Game1._screen_width / 2, Game1._screen_height / 2 + 50));
            _RunningLine = new RunningLine(this);
            _Blood = new ParticleSystem(LoadHelper.Textures[TextureEnum.blood], 6000, 500, true, false);
            _Fanfare = new ParticleSystem(LoadHelper.Textures[TextureEnum.star], 6000, 500, true, false);
            _Puff = new ParticleSystem(LoadHelper.Textures[TextureEnum.puff], 200, 80, true, true);
            SetChapter(Game1._Chapter);

            _fanfare_left_one = LoadHelper.Textures[TextureEnum.fanfare];
            _fanfare_left_two = LoadHelper.Textures[TextureEnum.fanfare];
            _fanfare_right_one = LoadHelper.Textures[TextureEnum.fanfare];
            _fanfare_right_two = LoadHelper.Textures[TextureEnum.fanfare];
        }
        public void TextOver(GameTime gameTime)
        {
            _closing_timestamp = gameTime.TotalGameTime;
            _done = true;
            LoadHelper.Sounds[SoundEnum.fanfare].Play();
            _Fanfare.Start(gameTime, new Vector2(Game1._screen_width/2, 100), 45);
        }
        public void Update(GameTime gameTime)
        {

            _rotation = _rotation + _rotation_rate;
            _Snake.Update(gameTime);
            if (!_bird_dead) _Bird.Update(gameTime);
            _RunningLine.Update(gameTime);
            if (!_bird_dead)
            {
                if (_Snake.OnBird() == true)
                {
                    _bird_dead = true;
                    _Blood.Start(gameTime, new Vector2(800, 500), 45);
                    _bird_dead_timestamp = gameTime.TotalGameTime;
                    LoadHelper.Sounds[SoundEnum.dun_dun_dun].Play();
                    LoadHelper.Sounds[SoundEnum.birdie].Play();
                }
            }
            if (_bird_dead)
            {
                
                if (5 < (gameTime.TotalGameTime.Seconds - _bird_dead_timestamp.Seconds))
                {
                    Game1.GameState = Game1.States.BirdEaten;
                }
            }
            _Blood.Update(gameTime, new Vector2(0,0), Color.White, new Vector2(0, 0));

            _chapter_color = Color.Multiply(_chapter_color, 0.965f);
            if (_done == true)
            {
                _Fanfare.Update(gameTime, new Vector2(-150, -50), Color.White, new Vector2(190, 300));
                if (5 < (gameTime.TotalGameTime.Seconds - _closing_timestamp.Seconds))
                {
                    Game1.ChapterComplete();
                }
            }
            if (_Puff_started == false)
            {
                _Puff_started = true;
                _Puff.Start(gameTime, new Vector2(820, 570), -1);
            }
            else _Puff.Update(gameTime, new Vector2(0,0), Color.White, new Vector2(820, 570));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //snake_body
            spriteBatch.Draw(_texture, new Rectangle((int)(Game1._screen_width / 2), (int)(Game1._screen_height / 2 + 50), _texture.Width, _texture.Height),
                                null, Color.White, _rotation, _center, SpriteEffects.None, 1.0f);

            if (!_bird_dead) _Bird.Draw(spriteBatch);
            _Snake.Draw(spriteBatch);
            _RunningLine.Draw(spriteBatch);
            _Blood.Draw(spriteBatch);
            spriteBatch.Draw(_texture_Chapter, new Rectangle(320, (int)_title_height, _texture_Chapter.Width, _texture_Chapter.Height), _chapter_color);
            spriteBatch.Draw(_texture_Chapter_id_two, new Rectangle(800, (int)_title_height, _texture_Chapter_id_one.Width, _texture_Chapter_id_one.Height), _chapter_color);
            spriteBatch.Draw(_texture_Chapter_id_one, new Rectangle(800 + _texture_Chapter_id_two.Width, (int)_title_height, _texture_Chapter_id_one.Width, _texture_Chapter_id_one.Height), _chapter_color);
            if (_Puff_started && !_bird_dead) _Puff.Draw(spriteBatch);
            if (_done == true)
            {
                
                spriteBatch.Draw(_fanfare_left_one, new Rectangle((int)_fanfare_position_left.X, (int)_fanfare_position_left.Y, _fanfare_left_one.Width, _fanfare_left_one.Height), Color.White);
                spriteBatch.Draw(_fanfare_left_two, new Rectangle((int)_fanfare_position_left.X+60, (int)_fanfare_position_left.Y+250, (int)( _fanfare_left_two.Width*1.2f), (int)(_fanfare_left_two.Height*1.2f)), Color.White);
                spriteBatch.Draw(_fanfare_right_one, new Rectangle((int)(_fanfare_position_right.X), (int)(_fanfare_position_right.Y), _fanfare_right_one.Width, _fanfare_right_one.Height),
                                null, Color.White, 0, _center, SpriteEffects.FlipHorizontally, 1.0f);
                spriteBatch.Draw(_fanfare_right_two, new Rectangle((int)(_fanfare_position_right.X - 60), (int)(_fanfare_position_right.Y + 250), (int)(_fanfare_right_two.Width * 1.2f), (int)(_fanfare_right_two.Height*1.2f)),
                                null, Color.White, 0, _center, SpriteEffects.FlipHorizontally, 1.0f);
                _Fanfare.Draw(spriteBatch);
            }
        }
    }
}
