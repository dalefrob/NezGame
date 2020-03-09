using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Tiled;

namespace Game1
{
    public class Actor : Component, IUpdatable
    {

        TiledMapRenderer map;

        VirtualButton useButton;
        VirtualButton rightButton;

        public override void OnAddedToEntity()
        {
            map = Entity.Scene.FindEntity("tiled-map").GetComponent<TiledMapRenderer>();
            var t = map.GetTileAtWorldPosition(new Vector2(0, 0));
            if(t.TilesetTile.Type == "Wall")
            {
                Console.WriteLine("Wall");
            }

            useButton = new VirtualButton();
            useButton.Nodes.Add(new VirtualButton.KeyboardKey(Keys.Space));

            rightButton = new VirtualButton();
            rightButton.Nodes.Add(new VirtualButton.KeyboardKey(Keys.Right));

        }

        public void Update()
        {
            Entity.Scene.Camera.Position = Vector2.Lerp(Entity.Scene.Camera.Position, Transform.Position, Time.DeltaTime * 2); // + (new Vector2(Core.GraphicsDevice.Viewport.Width, Core.GraphicsDevice.Viewport.Height) / 2);
            if (useButton.IsReleased)
            {
                Console.WriteLine("Bang");
            }

            if(rightButton.IsReleased)
            {
                Transform.Position += new Vector2(16, 0);
            }        
        }
    }
}
