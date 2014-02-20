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
    class Bird
    {
        private float _rotation_limit = 0.4f;
        private float _left_direction = 5f;
        private float _right_direction = -5f;

        private Vector2 _position_Bird;
        private Texture2D _texture_Bird;
        private Texture2D _texture_Left_Leg;
        private Texture2D _texture_Right_Leg;
        private Vector2 _position_left, _position_right, _center_left, _center_right;

        private float _rotation_Bird, _rotation_left, _rotation_right;
        private Vector2 _center_Bird;
        public Bird(Vector2 _new_position, float _new_rotation)
        {
            _position_Bird = _new_position;
            _rotation_Bird = _new_rotation;

            _texture_Left_Leg = LoadHelper.Textures[TextureEnum.bird_leg];
            _texture_Right_Leg = LoadHelper.Textures[TextureEnum.bird_leg];

            _texture_Bird = LoadHelper.Textures[TextureEnum.bird];
            _center_Bird = new Vector2(157, 101);

            _position_right = new Vector2(_position_Bird.X + 32, _position_Bird.Y + 43);
            _center_right = new Vector2(15, 4);
            _position_left = new Vector2(_position_Bird.X + 42, _position_Bird.Y + 43);
            _center_left = _center_right;
            _position_Bird.Y = _position_Bird.Y+_center_Bird.Y/2;
            _position_Bird.X = _position_Bird.X + 40;
        }
        public void Update(GameTime gameTime)
        {
            //_rotation_right = 0;
            //_rotation_left = 0;

            _rotation_right = _rotation_right + (float)(_right_direction * Math.PI) / 100;
            if (_rotation_right > _rotation_limit) _right_direction = -_right_direction;
            if (_rotation_right < -_rotation_limit) _right_direction = -_right_direction;

            _rotation_left = _rotation_left + (float)(_left_direction * Math.PI) / 100;
            if (_rotation_left > _rotation_limit) _left_direction = -_left_direction;
            if (_rotation_left < -_rotation_limit) _left_direction = -_left_direction;
          

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture_Left_Leg, new Rectangle((int)(_position_left.X), (int)(_position_left.Y), _texture_Left_Leg.Width, _texture_Left_Leg.Height),
                                null, Color.White, _rotation_left + _rotation_Bird, _center_left, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(_texture_Bird, new Rectangle((int)(_position_Bird.X), (int)(_position_Bird.Y), _texture_Bird.Width, _texture_Bird.Height),
                                null, Color.White, _rotation_Bird, _center_Bird, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(_texture_Right_Leg, new Rectangle((int)(_position_right.X), (int)(_position_right.Y), _texture_Right_Leg.Width, _texture_Right_Leg.Height),
                                null, Color.White, _rotation_right + _rotation_Bird, _center_right, SpriteEffects.None, 1.0f);
        }
    }
}
