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
    class Snake
    {


        private Texture2D UpperJaw;
        private Texture2D LowerJaw;
        private Texture2D Head;
        private Vector2 _position_UpperJaw, _position_LowerJaw;

        private Color _color_head;
        


        private Vector2 _position_Head;
        private float _rotation;
        private Vector2 _center_UpperJaw;
        private Vector2 _center_LowerJaw;
        private Vector2 _center_Head;
        private bool _moving = false;
        public void Reset()
        {
            _rotation = (float)(Math.PI / 2);
            _color_head.A = 0;
            _color_head.R = 0;
            _color_head.G = 0;
            _color_head.B = 0;
        }
        public Snake(Vector2 _new_position)
        {
            _position_Head = _new_position;
            Head = LoadHelper.Textures[TextureEnum.snake_head];
            UpperJaw = LoadHelper.Textures[TextureEnum.upper_jaw];
            LowerJaw = LoadHelper.Textures[TextureEnum.lower_jaw];
            _center_Head = new Vector2(Head.Height/2, Head.Width/2);
            _center_UpperJaw = _center_Head;
            _center_LowerJaw = _center_Head;
            _position_UpperJaw = _position_Head;
            _position_LowerJaw = _position_Head;
            Reset();
        }
        public bool OnBird()
        {
            if (_rotation > -2.1) return false;
            return true;
        }
        public void Move()
        {


            _moving = true;

            if (_rotation > -2.1)
                _rotation = _rotation - (float)(Math.PI) / 70;
            if (_color_head.A < 250)
            {
                
                _color_head.A = (byte)(_color_head.A + 10);
                _color_head.R = (byte)(_color_head.R + 10);
                _color_head.G = (byte)(_color_head.G + 10);
                _color_head.B = (byte)(_color_head.B + 10);
            }
                    


        }
        public void Update(GameTime gameTime)
        {
            
            if (_moving == false)
                _color_head = Color.Multiply(_color_head, 0.55f);
            _moving = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Head, _position_Head, null, _color_head, _rotation, _center_Head, 1.0f, SpriteEffects.None, 1.0f);
        }
    }
}
