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
    class Particle
    {

        private double _created;
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _direction;
        private Color _init_color;
        private Color _color;
        private float _angle;
        private Vector2 _center;
        private bool _fade;

        public Particle(double gameTime, Texture2D _new_texture, Vector2 _new_position, Vector2 _new_direction, Color _new_color, float _new_angle, bool _new_fade)
        {
            _created = gameTime;
            _texture = _new_texture;
            _position = _new_position;
            _direction = _new_direction;
            _init_color = _new_color;
            _color = _new_color;
            _angle = _new_angle;
            _center = new Vector2(_texture.Width / 2, _texture.Height / 2);
            _fade = _new_fade;

        }

        public double Created()
        {
            return _created;
        }

        public void Update(GameTime gameTime)
        {
            _position.X = _position.X + _direction.X*5;
            _position.Y = _position.Y + _direction.Y*5;
            _angle = _angle + 0.01f;

            if (_fade)
                _color = Color.Multiply(_color, 0.95f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _angle, _center, 1.0f, SpriteEffects.None, 1.0f);

        }
    }
}

