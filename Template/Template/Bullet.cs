using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Bullet
    {
        private Texture2D _bullettexture;
        private Vector2 _bulletposition;
        private Rectangle _bullethitbox = new Rectangle();
        private float speed = 100f;
        private bool invert;

        public Vector2 Bulletposition { get { return _bulletposition; } set { _bulletposition = value; } }
        public Rectangle Bullethitbox { get { return _bullethitbox; } set { _bullethitbox = value; } }


        public Bullet(Texture2D bullettexture, Vector2 bulletposition, bool invert)
        {
            _bullettexture = bullettexture;
            _bulletposition = bulletposition;
            _bullethitbox.Size = new Point(0, 0);
            this.invert = invert;
        }

        public void Update()
        {
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!invert)
            {
                spriteBatch.Draw(_bullettexture, new Rectangle(_bulletposition.ToPoint(), new Point(200, 100)), Color.White);
            }
            else
            {
                spriteBatch.Draw(_bullettexture, new Rectangle(_bulletposition.ToPoint(), new Point(200, 100)), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }

        }

        private void Move()
        {
            _bulletposition = new Vector2(_bulletposition.X - 0, _bulletposition.Y);
            if (!invert)
            {
                _bulletposition.X += speed;
            }
            else
            {
                _bulletposition.X -= speed;
            }

            _bullethitbox.Location = _bulletposition.ToPoint();
        }
    }
}
