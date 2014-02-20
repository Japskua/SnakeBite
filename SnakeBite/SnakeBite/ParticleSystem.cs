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
    class ParticleSystem
    {
        private List<Particle> _Particles;


        private List<Texture2D> _textures;

        private Texture2D _texture;
        private int _energy;
        private int _frequency;
        private double _last_particle_time_stamp;
        private float _angle;
        private bool _spinning;
        private Random _random;
        private bool _fade;
        private bool _enable;
        private int _amount;

        public ParticleSystem(Texture2D _new_texture, int _new_energy, int _new_frequency, bool _random_spin, bool _new_fade)
        {
            
            _texture = _new_texture;
            _fade = _new_fade;
            _energy = _new_energy;
            _frequency = _new_frequency;
            _last_particle_time_stamp = 0;
            _Particles = new List<Particle>();
            _spinning = _random_spin;
            _random = new Random();
            _textures = new List<Texture2D>();
            _textures.Add(_new_texture);
            _enable = false;

           
        }

        public void Start(GameTime gameTime,Vector2 _position, int _new_amount)
        {
            _amount = _new_amount;
            if (_amount == -1) Enable();
            for (int i = 0; i < _amount; i++)
                CreateParticle(gameTime, new Vector2(0,0), Color.White, _position);
        }

        public void SetFrequency(int _new_frequency)
        {
            _frequency = _new_frequency;
        }

        public void Enable()
        {
            _enable = true;
        }

        public void Disable()
        {
            _enable = false;
        }

        public void AddTexture(Texture2D _new_texture)
        {
            _textures.Add(_new_texture);
        }

        private void CreateParticle(GameTime gameTime, Vector2 _direction, Color _color, Vector2 _position)
        {
            if (_spinning)
            {
                _angle = (float)(_random.NextDouble() * Math.PI);
            }
            else _angle = 0;

            _direction.X = (float)(_direction.X + (_random.NextDouble() - 0.5f) * 1.9f);
            _direction.Y = (float)(_direction.Y + (_random.NextDouble() - 0.5f) * 1.9f);
            _last_particle_time_stamp = gameTime.TotalGameTime.TotalMilliseconds;
            _Particles.Add(new Particle(gameTime.TotalGameTime.TotalMilliseconds, _textures[_random.Next(_textures.Count)], _position, _direction, _color, _angle, _fade));

        }

        public void Update(GameTime gameTime, Vector2 _direction, Color _color, Vector2 _position)
        {

            if (_enable)
            {
                if (_frequency < gameTime.TotalGameTime.TotalMilliseconds - _last_particle_time_stamp)
                    CreateParticle(gameTime, _direction, _color, _position);
            }

            _Particles.ForEach(delegate(Particle _particle)
            {
                if (_energy < gameTime.TotalGameTime.TotalMilliseconds - _particle.Created())
                    _Particles.RemoveAt(_Particles.IndexOf(_particle));
            });

            _Particles.ForEach(delegate(Particle _particle)
            {
                _particle.Update(gameTime);
            });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _Particles.ForEach(delegate(Particle _particle)
            {
                _particle.Draw(spriteBatch);
            });
        }


    }
}

