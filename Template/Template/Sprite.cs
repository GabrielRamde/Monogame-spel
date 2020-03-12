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
        public int bulletammo; 
        private Vector2 position;
        private float speed = 20f;
        private Input input;
        private bool invert;
        private Rectangle size;

        public Vector2 Position{ get { return position; } set { position = value; } }
        public Input Input{ get { return input; } set { input = value; } }

        public Sprite(Texture2D texture, bool invert)
        {
            _texture = texture;
            this.invert = invert;
            size.Size = new Point(350, 200);
        }

        public void Update()
        {
            Move();
            if (Keyboard.GetState().IsKeyDown(input.Shoot)&& bulletammo>0)
            {
                
            }
            else if (Keyboard.GetState().IsKeyDown(input.Shoot) && bulletammo < 0)
            {

            }
        }

        private void Move()
        {
            if (input == null)
                return;


            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                position.Y -= speed;
            }

            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                position.Y += speed;
            }

            if (position.Y + size.Height > 1090)
            {
                position.Y = 1090 - size.Height;
            }
            else if (position.Y < -40)
            {
                position.Y = -40;
            }
            size.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!invert)
                spriteBatch.Draw(_texture, size, Color.White);
            else
                spriteBatch.Draw(_texture, size,null, Color.White,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);
        }
          
    }
}
