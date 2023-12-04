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

namespace Snake
{
    

    internal class Game :GameWindow
    {
        int side = 0;
        
     
        Snake snake = new Snake();
      
      
        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeSettings)
 : base(gameWindowSettings, nativeSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();
      
           
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
           

        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            snake.Drawsnake();
           
            snake.Move(side);
           
            SwapBuffers();
            
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
        }
        protected override void OnKeyUp(KeyboardKeyEventArgs e)
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
           
         

        }

    }

}
