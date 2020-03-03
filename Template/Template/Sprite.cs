using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Sprite
    {
        private Texture2D _texture;

        public Vector2 Position;
        public float Speed = 35f;
        public Input Input;
        private bool invert;

        public Sprite(Texture2D texture, bool invert)
        {
            _texture = texture;
            this.invert = invert;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Input == null)
                return;

            if(Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Position.Y -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Position.Y += Speed;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!invert)
                spriteBatch.Draw(_texture, Position, Color.White);
            else
                spriteBatch.Draw(_texture, new Rectangle(Position.ToPoint(),new Point(_texture.Width,_texture.Height)),null, Color.White,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);
        }
          
    }
}
