using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Background_Dystopia
{
    public class Game1 : Game
    {
        #region Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Reference
        public static int screenWidth;
        public static int screenHieght;
        public static Vector2 screenMiddle;

        Scrolling scrolling_1;
        Scrolling scrolling_2;
        Sub_Scrolling s_scrolling_1;
        Sub_Scrolling s_scrolling_2;
        Sky background_Sky_1;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            #region Graphics Control
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            // Reference
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHieght = GraphicsDevice.Viewport.Height;
            screenMiddle = new Vector2(screenWidth / 2, screenHieght / 2);
            #endregion
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Main Menu Background
            scrolling_1 = new Scrolling(Content.Load<Texture2D>("Title_Screen_Background_CityScape_V1_x4_GIMP"), new Rectangle(0, 80,1920, 544));
            scrolling_2 = new Scrolling(Content.Load<Texture2D>("Title_Screen_Background_CityScape_V1_x4_GIMP"), new Rectangle(1920, 80, 1920, 544));

            s_scrolling_1 = new Sub_Scrolling(Content.Load<Texture2D>("Title_Screen_Background_Mountain_Range_x4_GIMP"), new Rectangle(0, 76, 1920, 152));
            s_scrolling_2 = new Sub_Scrolling(Content.Load<Texture2D>("Title_Screen_Background_Mountain_Range_x4_GIMP"), new Rectangle(1920, 76, 1920, 152));

            background_Sky_1 = new Sky(Content.Load<Texture2D>("Title_Screen_Background_Sky_x4"), new Rectangle(0, 0, screenWidth, 152));
            #endregion
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Scrolling Backgrounds
            #region Scrolling_1 - 2
            if (scrolling_1.rectangle.X + scrolling_1.rectangle.Width < 0)
            {
                scrolling_1.rectangle.X = scrolling_2.rectangle.X + scrolling_2.rectangle.Width;
            }
            if (scrolling_2.rectangle.X + scrolling_1.rectangle.Width < 0)
            {
                scrolling_2.rectangle.X = scrolling_2.rectangle.X + scrolling_2.rectangle.Width;
            }

            scrolling_1.Update();
            scrolling_2.Update();
            #endregion

            #region Sub Scrolling_1 - 2
            if (s_scrolling_1.rectangle.X + s_scrolling_1.rectangle.Width < 0)
            {
                s_scrolling_1.rectangle.X = s_scrolling_2.rectangle.X + s_scrolling_2.rectangle.Width;
            }
            if (s_scrolling_2.rectangle.X + s_scrolling_1.rectangle.Width < 0)
            {
                s_scrolling_2.rectangle.X = s_scrolling_2.rectangle.X + s_scrolling_2.rectangle.Width;
            }

            s_scrolling_1.Update();
            s_scrolling_2.Update();
            #endregion


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            #region Main Menu Background Drawing
            background_Sky_1.Draw(spriteBatch);

            s_scrolling_1.Draw(spriteBatch);
            s_scrolling_2.Draw(spriteBatch);

            scrolling_1.Draw(spriteBatch);
            scrolling_2.Draw(spriteBatch);
            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
