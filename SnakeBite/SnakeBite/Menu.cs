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
    class Menu
    {
        MouseState mouseStateCurrent, mouseStatePrevious;

        private Texture2D _texture_Chapter_id_one, _texture_Chapter_id_two;
        private int _Chapter;
        
        List<Cage> Cages = new List<Cage>();
        public void SetChapter(int _current_chapter)
        {
            _Chapter = _current_chapter;
            _texture_Chapter_id_two = LoadHelper.Numbers[NumberEnum.num_0];
            switch (_current_chapter % 10)
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
            if (_current_chapter > 10)
            {
                switch ((_current_chapter - (_current_chapter % 10)) / 10)
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
        }
	    
        public void Update(GameTime gameTime)
        {
            mouseStateCurrent = Mouse.GetState();
            // Move the sprite to the current mouse position when the left button is pressed
            if (mouseStateCurrent.LeftButton == ButtonState.Pressed &&
                mouseStatePrevious.LeftButton == ButtonState.Released)
            {

                Console.WriteLine(mouseStateCurrent.X);
                if (mouseStateCurrent.X > 850 && mouseStateCurrent.X < 1150 &&
                    mouseStateCurrent.Y > 400 && mouseStateCurrent.Y < 523)
                {
                    //START BUTTON PRESSED
                    //Game1.GameState = Game1.States.Game;
                    Game1.StartChapter();

                }
                if (mouseStateCurrent.X > 850 && mouseStateCurrent.X < 1150 &&
                    mouseStateCurrent.Y > 550 && mouseStateCurrent.Y < 690)
                {
                    //EXIT BUTTON PRESSED
                    Game1.GameState = Game1.States.Closing;
                   
                    
                }


            }

            // Change the horizontal direction of the sprite when the right mouse button is clicked
            if (mouseStateCurrent.RightButton == ButtonState.Pressed &&
                mouseStatePrevious.RightButton == ButtonState.Released)
            {
                
            }

            mouseStatePrevious = mouseStateCurrent;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.button_start], new Rectangle(850, 400, LoadHelper.Textures[TextureEnum.button_start].Width, LoadHelper.Textures[TextureEnum.button_start].Height), Color.White);
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.button_exit], new Rectangle(850, 550, LoadHelper.Textures[TextureEnum.button_exit].Width, LoadHelper.Textures[TextureEnum.button_exit].Height), Color.White);
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.cage], new Rectangle(0, 0, LoadHelper.Textures[TextureEnum.cage].Width, LoadHelper.Textures[TextureEnum.cage].Height), Color.White);
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.chapter], new Rectangle(550, 30, LoadHelper.Textures[TextureEnum.chapter].Width, LoadHelper.Textures[TextureEnum.chapter].Height), Color.White);
            if (_texture_Chapter_id_one != null)
            {
                spriteBatch.Draw(_texture_Chapter_id_two, new Rectangle(1050, (int)30, _texture_Chapter_id_one.Width, _texture_Chapter_id_one.Height), Color.White);
                spriteBatch.Draw(_texture_Chapter_id_one, new Rectangle(1050 + _texture_Chapter_id_two.Width, (int)30, _texture_Chapter_id_one.Width, _texture_Chapter_id_one.Height), Color.White);
           
            }
        }
    }
}

