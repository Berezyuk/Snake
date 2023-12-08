using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;

using System.Drawing;

namespace Snake
{
    

    internal class Game :GameWindow
    {
        int side = 0;
        
     
        Snake snake = new Snake();
        Food food = new Food();
        Background background = new Background();
        List<int> foods = new List<int>();
        int backgroundId;

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeSettings)
 : base(gameWindowSettings, nativeSettings)
        {
            foods.Add(GameTextures.LoadTexture("Content/apple.jpg"));
            backgroundId = GameTextures.LoadTexture("Content/background.jpg");
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0, 0, 0, 0);

            

        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if(KeyboardState.IsKeyDown(Keys.Left))
            {
                side = 3;
            }
            if( KeyboardState.IsKeyDown(Keys.Right))
            { 
                side = 2; 
            }
            if(KeyboardState.IsKeyDown(Keys.Up))
            {
                side = 0;
            }
            if(KeyboardState.IsKeyDown(Keys.Down))
            {
                side = 1;
            }

        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
           // background.DrawBackground(backgroundId);

            snake.Drawsnake();
                snake.Move(side);
                //food.DrawfoodwithTextures(foods[0]);
                food.Drawfood();
                food.HeadAchivesFood(snake.x, snake.y, food.x, food.y, snake, snake.commands);
                SwapBuffers();
           

          
            
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }
        /*protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {
            base.OnKeyUp(e);
            
            if (e.Key == Keys.Left) 
            {
                
                side = 3;
               
                
            }
            if (e.Key == Keys.Right)
            {
                side = 2;
                
               
            }
            if (e.Key == Keys.Up)
            {
                side = 0;
               
             
            }
            if (e.Key == Keys.Down)
            {
                side = 1;
               
            }
           
         

        }*/
        
    }

}
