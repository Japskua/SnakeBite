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
    class Letter
    {
        private Texture2D _texture;
        private Vector2 _position;
        private char _letter;
        public Letter(char _new_letter, Vector2 _new_position)
        {
            _position = _new_position;
            _letter = _new_letter;
            switch (_letter)
            {
                case 'a': _texture = LoadHelper.Letters[LetterEnum.A]; break;
                case 'b': _texture = LoadHelper.Letters[LetterEnum.B]; break;
                case 'c': _texture = LoadHelper.Letters[LetterEnum.C]; break;
                case 'd': _texture = LoadHelper.Letters[LetterEnum.D]; break;
                case 'e': _texture = LoadHelper.Letters[LetterEnum.E]; break;
                case 'f': _texture = LoadHelper.Letters[LetterEnum.F]; break;
                case 'g': _texture = LoadHelper.Letters[LetterEnum.G]; break;
                case 'h': _texture = LoadHelper.Letters[LetterEnum.H]; break;
                case 'i': _texture = LoadHelper.Letters[LetterEnum.I]; break;
                case 'j': _texture = LoadHelper.Letters[LetterEnum.J]; break;
                case 'k': _texture = LoadHelper.Letters[LetterEnum.K]; break;
                case 'l': _texture = LoadHelper.Letters[LetterEnum.L]; break;
                case 'm': _texture = LoadHelper.Letters[LetterEnum.M]; break;
                case 'n': _texture = LoadHelper.Letters[LetterEnum.N]; break;
                case 'o': _texture = LoadHelper.Letters[LetterEnum.O]; break;
                case 'p': _texture = LoadHelper.Letters[LetterEnum.P]; break;
                case 'q': _texture = LoadHelper.Letters[LetterEnum.Q]; break;
                case 'r': _texture = LoadHelper.Letters[LetterEnum.R]; break;
                case 's': _texture = LoadHelper.Letters[LetterEnum.S]; break;
                case 't': _texture = LoadHelper.Letters[LetterEnum.T]; break;
                case 'u': _texture = LoadHelper.Letters[LetterEnum.U]; break;
                case 'v': _texture = LoadHelper.Letters[LetterEnum.V]; break;
                case 'w': _texture = LoadHelper.Letters[LetterEnum.W]; break;
                case 'x': _texture = LoadHelper.Letters[LetterEnum.X]; break;
                case 'y': _texture = LoadHelper.Letters[LetterEnum.Y]; break;
                case 'z': _texture = LoadHelper.Letters[LetterEnum.Z]; break;
                case ' ': _texture = LoadHelper.Letters[LetterEnum.space]; break;
                case '.': _texture = LoadHelper.Letters[LetterEnum.dot]; break;
                case ',': _texture = LoadHelper.Letters[LetterEnum.comma]; break;
                case '!': _texture = LoadHelper.Letters[LetterEnum.emotion_mark]; break;
                case '?': _texture = LoadHelper.Letters[LetterEnum.question_mark]; break;

            }
        }
        public void Update(GameTime gameTime, float _new_speed)
        {
            _position.X = _position.X - _new_speed;
            
        }
        public float GetX()
        {
            return _position.X;
        }
        public char GetLetter()
        {
            return _letter;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height), Color.White);
        }
    }
}
