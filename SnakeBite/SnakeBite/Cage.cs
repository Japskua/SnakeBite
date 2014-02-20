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
    class Cage
    {

        public Cage()
        {

        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.cage], new Rectangle(0, 0, LoadHelper.Textures[TextureEnum.cage].Width, LoadHelper.Textures[TextureEnum.cage].Height), Color.White);
            spriteBatch.Draw(LoadHelper.Textures[TextureEnum.bird], new Rectangle(0, 0, LoadHelper.Textures[TextureEnum.bird].Width, LoadHelper.Textures[TextureEnum.bird].Height), Color.White);
        }
    
    }
}
