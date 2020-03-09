using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {
        public Game1() : base(320, 320, false, true, "Dale's NEZ Game")
        {

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            // TODO: Add your initialization logic here

            var scene = new Scene
            {
                ClearColor = Color.CornflowerBlue
            };
            scene.AddRenderer(new DefaultRenderer());

            // load a TiledMap and move it back so is drawn before other entities
            var map = Content.LoadTiledMap("Content/TestMap.tmx");
            var tiledEntity = scene.CreateEntity("tiled-map");
            tiledEntity.AddComponent(new TiledMapRenderer(map, "Base"));


            var texture = scene.Content.LoadTexture("Content/Spider.png", true);
            var playerEntity = scene.CreateEntity("player");
            playerEntity.Transform.Position = new Vector2(100, 100);
            playerEntity.AddComponent(new Actor());
            playerEntity.AddComponent(new SpriteRenderer(texture));

            Scene = scene;
        }
  
    }
}
