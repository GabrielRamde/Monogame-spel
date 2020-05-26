using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Template
{
    public class Game1 : Game //Mina olika variablar, lista, texturer, positioner
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Random _random;
        private int Random;

        public static int bredd;
        public static int hojd;

        private List<Sprite> _sprites;
        public Texture2D _texture;
        private Vector2 _position;
        private float speed = 30f;

        private Texture2D _background;
        private Vector2 _backgroundpos = new Vector2(0, 0);
        private Texture2D texture;

        private Texture2D _bullettexture;
        private Vector2 _bulletposition;

        private int screen = 0;

        private SpriteFont font;
        private float countdown = 0;
        
        

        public Game1() 
        {
            graphics = new GraphicsDeviceManager(this); //skärmstorlek på spelet
            hojd = graphics.PreferredBackBufferHeight = 1080;
            bredd = graphics.PreferredBackBufferWidth = 1920;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _random = new Random();



            base.Initialize();
        }

        protected override void LoadContent() //texturer på mina saker och positioner i en lista, samt knappar för vad dem ska göra
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("ak-47");

            _bullettexture = Content.Load<Texture2D>("bullet");

            _sprites = new List<Sprite>()
            {
                new Sprite(texture, _bullettexture, false) //första spelare
                {
                    Position = new Vector2(0, 300),
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Shoot = Keys.Space,
                    }
                },
                new Sprite(texture, _bullettexture, true) //andra spelare
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

            _background = Content.Load<Texture2D>("dust2"); // Bakgrund till spelet
            font = Content.Load<SpriteFont>("Countdown"); // Text för nedräkning

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
            if (screen == 1) //Spelskärm
            {


                foreach (var sprite in _sprites)

                    sprite.Update();


                if (_sprites[1].Bullet != null && _sprites[0].Size.Intersects(_sprites[1].Bullet.Bullethitbox))
                {
                    _sprites[0].Alive = false;
                    screen = 2;
                }
                else if (_sprites[0].Bullet != null && _sprites[1].Size.Intersects(_sprites[0].Bullet.Bullethitbox))
                {
                    _sprites[1].Alive = false;
                    screen = 2;
                }
            }
            else if (screen == 2) //Slutskärm
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    screen = 0;
                    countdown = 0;
                    _sprites[0].Alive = true;
                    _sprites[1].Alive = true;
                    _sprites[0].Bullet = null;
                    _sprites[1].Bullet = null;
                    _sprites[0].bulletammo = 0;
                    _sprites[1].bulletammo = 0;
                    _sprites[0].Playerbullet = 0;
                    _sprites[1].Playerbullet = 0;
                    RandomlyGiveBullet();
                }
            }
            else if (screen == 0) //Startskärm
            {
                countdown += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (countdown > 3)
                {
                    screen = 1;
                }
            }
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
            if (screen == 1) //Spelskärm
            {
                foreach (var sprite in _sprites)
                    sprite.Draw(spriteBatch);
                spriteBatch.Draw(_bullettexture, new Rectangle(100 + Random * 1720, 50, 100, 25), Color.White);
                    
            }

            else if (screen == 2) //Slutskärm
            {
                spriteBatch.DrawString(font, ("Press enter for restart"), new Vector2(560, 190), Color.Black);
                spriteBatch.DrawString(font,("Player Won"), new Vector2(660, 450), Color.Black);
            }
            else if (screen == 0) //Startskärm
            {
                spriteBatch.DrawString(font,(3-(int)countdown).ToString(), new Vector2(960, 390), Color.Black);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }


        void RandomlyGiveBullet() //bestämmer vem som ska få skottet
        {
            Random = _random.Next(0, 2);
            _sprites[Random].bulletammo = 1;
        }            
    }
}
