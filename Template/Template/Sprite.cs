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
        private Texture2D _bullettexture;
        public int bulletammo = 0; 
        private Vector2 position;
        private Vector2 _bulletposition;
        private float speed = 30f;
        private Input input;
        private bool invert;
        private Rectangle size;
        private Bullet bullet;
        private static int playerbullet;
        private int playerid;
        private bool alive = true;
                  
        public Vector2 Position{ get { return position; } set { position = value; } } //gör så man kan använda private variablar
        public Input Input{ get { return input; } set { input = value; } }

        public Rectangle Size{ get { return size; } set { size = value; } }

        public Bullet Bullet { get { return bullet; } set { bullet = value; } }

        public bool Alive { get => alive; set => alive = value; }

        public int Playerbullet { get => playerbullet; set => playerbullet = value; }

        public Sprite(Texture2D texture, Texture2D btexture, bool invert)
        {
            _texture = texture;
            _bullettexture = btexture;
            this.invert = invert;
            size.Size = new Point(350, 200);
            playerid = invert ? 1 : 2;
        }

        public void Update()
        {
            Move();
            if (Keyboard.GetState().IsKeyDown(input.Shoot)&& bulletammo>0)
            {
                _bulletposition = position;
                bullet = new Bullet(_bullettexture, _bulletposition, invert);
                bulletammo--; 
                playerbullet = playerid == 2?1:2;
            }
            if (playerbullet == playerid && bulletammo <= 0)
            {
                bulletammo++;
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

            if (position.Y + size.Height > 1080)
            {
                position.Y = 1080 - size.Height;
            }
            else if (position.Y < -40)
            {
                position.Y = -40;
            }
            size.Location = position.ToPoint();

            if (bulletammo == 0 && bullet != null)
            {
                bullet.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color drawColor = Color.White;
            if (!alive)
            {
                drawColor = Color.Red;
            }
            if(!invert)
                spriteBatch.Draw(_texture, size, drawColor);
            else
                spriteBatch.Draw(_texture, size,null, drawColor,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);

            if (bulletammo == 0 && bullet != null)

            

                bullet.Draw(spriteBatch);
                

        }
          
    }
}
