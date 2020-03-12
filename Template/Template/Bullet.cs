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
        private float speed = 30f;

        public Vector2 Bullettposition { get { return _bulletposition; } set { _bulletposition = value; } }

        public Bullet(Texture2D bullettexture)
        {
            _bullettexture = bullettexture;
        }

        public void Update()
        {
            Move();        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_bullettexture, new Rectangle(_bulletposition.ToPoint(), new Point(50, 50)), Color.White);
        }

        private void Move()
        {
            _bulletposition = new Vector2(_bulletposition.X, _bulletposition.Y);
        }
    }
}
