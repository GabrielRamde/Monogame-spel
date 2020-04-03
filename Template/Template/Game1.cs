using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Template
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Random _random;

        public static int bredd;
        public static int hojd;

        private List<Sprite> _sprites;
        public Texture2D _texture;
        public Vector2 _position;
        public float speed = 30f;

        public Texture2D _background;
        public Vector2 _backgroundpos = new Vector2(0, 0);

        public Texture2D _bullettexture;
        public Vector2 _bulletposition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            hojd = graphics.PreferredBackBufferHeight = 1080;
            bredd = graphics.PreferredBackBufferWidth = 1920;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _random = new Random();



            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var texture = Content.Load<Texture2D>("ak-47");

            _bullettexture = Content.Load<Texture2D>("bullet");

            _sprites = new List<Sprite>()
            {
                new Sprite(texture, _bullettexture, false)
                {
                    Position = new Vector2(0, 300),
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Shoot = Keys.Space,
                    }
                },
                new Sprite(texture, _bullettexture, true)
                {
                    Position = new Vector2(1575, 300),
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Shoot = Keys.Enter,
                    }
                },
            };

            _background = Content.Load<Texture2D>("dust2");

            _bullettexture = Content.Load<Texture2D>("bullet");
            _bulletposition = new Vector2(0, 0);

            RandomlyGiveBullet();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (var sprite in _sprites)

                sprite.Update();
           
           /* if (_sprites[0].Size.Intersects(_sprites[1].Bullet.Bullethitbox))
            {
                _sprites[0].Alive = false;    
            }
            else if (_sprites[1].Size.Intersects(_sprites[0].Bullet.Bullethitbox))
            {
                _sprites[1].Alive = false;
            }
            else 
            */
                base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            Rectangle backgroundRec = new Rectangle();
            backgroundRec.Location = _backgroundpos.ToPoint();
            backgroundRec.Size = new Point(bredd, hojd);
            spriteBatch.Draw(_background, backgroundRec, Color.White);
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }


        void RandomlyGiveBullet()
        {
            int Random = _random.Next(0, 2);
            _sprites[Random].bulletammo = 1;
        }            
    }
}
