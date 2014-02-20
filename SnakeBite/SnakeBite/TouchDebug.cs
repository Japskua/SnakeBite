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
    class TouchDebug
    {
        private bool _has_touch;
        private Vector2 _touch;


        public TouchDebug()
        {

        }




        public void SetTouch(Vector2 _new_touch)
        {
            _has_touch = true;
            _touch = _new_touch;
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            if (_has_touch)
                spriteBatch.DrawString(LoadHelper.Fonts[FontEnum.Arial22], "Touch: " + ((int)_touch.X).ToString() + " x " + ((int)_touch.Y).ToString(), new Vector2(60, 10), Color.White, (float)Math.PI / 2, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);
        }



    }
}
