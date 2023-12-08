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
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.ComponentModel.Design;

namespace Snake
{
    internal class Food
    {
        Random random = new Random();
        public List<float[]> x = new List<float[]> { new float[4] };
        public List<float[]> y = new List<float[]> { new float[4] };
       


        public Food()
        {
            ChangeCoordinates();
        }
       
        public void DrawfoodwithTextures(int foodsId)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
           
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);
            GL.BindTexture(TextureTarget.Texture2D, foodsId);
            GL.Color4(Color4.Red);
            GL.Begin(PrimitiveType.Polygon);

            GL.TexCoord2(x[0][0], y[0][0]);
            GL.Vertex2(x[0][0], y[0][0]);
            GL.TexCoord2(x[0][1], y[0][1]);
            GL.Vertex2(x[0][1], y[0][1]);
            GL.TexCoord2(x[0][2], y[0][2]);
            GL.Vertex2(x[0][2], y[0][2]);
            GL.TexCoord2(x[0][3], y[0][3]);
            GL.Vertex2(x[0][3], y[0][3]);

            GL.End();
        }
        public void Drawfood()
        {
            GL.Color4(Color4.Red);
            GL.Begin(PrimitiveType.Polygon);
         
            GL.Vertex2(x[0][0], y[0][0]);
          
            GL.Vertex2(x[0][1], y[0][1]);
          
            GL.Vertex2(x[0][2], y[0][2]);
       
            GL.Vertex2(x[0][3], y[0][3]);

            GL.End();
        }
       
        public void HeadAchivesFood(List <float[]> snakeX, List <float[]> snakeY, List <float[]> foodX, List <float[]> foodY, Snake snake, List<int> commands) 
        {
            bool flag = false;

            switch (commands[0])
            {
                case 0:
                    if ((snakeY[0][2] > y[0][0] && snakeY[0][3] > y[0][1]) && 
                        ((snakeX[0][0] > x[0][0] && snakeX[0][1] > x[0][1] && snakeX[0][0] < x[0][1]) ||
                        (snakeX[0][0] < x[0][0] && snakeX[0][1] < x[0][1] && snakeX[0][1] > x[0][0]) ||
                        (snakeX[0][0] > x[0][0] && snakeX[0][2] < x[0][1]))
                        )
                    {
                     
                        flag = true;
                    }
                    break;
                case 1:
                    if ((snakeY[0][2] < y[0][3] && snakeY[0][3] < y[0][2]) &&
                       ((snakeX[0][2] > x[0][3] && snakeX[0][3] > x[0][2] && snakeX[0][2] < x[0][2]) ||
                        (snakeX[0][2] < x[0][2] && snakeX[0][3] < x[0][2] && snakeX[0][3] > x[0][3]) ||
                        (snakeX[0][2] > x[0][3] && snakeX[0][3] < x[0][2])) 
                        )
                    {
                        
                        flag = true;
                    }
                    break;
                case 2:// right
                    if ((snakeX[0][2] > x[0][0] && snakeX[0][3] > x[0][3]) &&
                        ((snakeY[0][3] > y[0][0] && snakeY[0][2] > y[0][0] && snakeY[0][2] < y[0][3]) ||
                        (snakeY[0][2] < y[0][3] && snakeY[0][3] < y[0][3] && snakeY[0][3] > y[0][0]) ||
                        (snakeY[0][3] < y[0][3] && snakeY[0][2] > y[0][0]))
                        )
                    {
                       
                        flag = true;
                    }
                    break;
                case 3://left
                    if ((snakeX[0][2] < x[0][2] && snakeX[0][3] < x[0][1]) &&
                        ((snakeY[0][3] > y[0][1] && snakeY[0][2] > y[0][2] && snakeY[0][3] < y[0][2]) ||
                        (snakeY[0][2] < y[0][2] && snakeY[0][3] < y[0][2] && snakeY[0][2] > y[0][1])  ||
                        (snakeY[0][2] < y[0][2] && snakeY[0][3] > y[0][1]))
                        )
                    {
                      
                        flag = true;
                    }
                    break;
            }
                
            if (flag)
            {
                flag = false;
                ChangeCoordinates();
                //пропадает еда, появляется новая
                //предусмотреть правильное добавление координат  цикл от последних координат по икс отнимать 0.1 вправо игрик оставляем 
                //если вверх то икс оставляем y отнимаем 0.1f
                //если вниз то икс оставляем игрик прибавляем 0.1
                //если влево игрик оставляем икс прибавляем
                // если вправо игрик оставялем икс отнимаем
                Console.WriteLine("Съел");
                
                snake.Grow();
                
            }
            
        }
        
        public void ChangeCoordinates()
        {
            int xChange = random.Next(-7, 8);
            int yChange = random.Next(-7, 8);

            float dX = 0.1f * xChange;
            float dY = 0.1f * yChange;


            x[0][0] = dX; y[0][0] = dY;
            x[0][1] = dX + 0.15f; y[0][1] = dY;
            x[0][2] = dX + 0.15f; y[0][2] = dY + 0.15f;
            x[0][3] = dX; y[0][3] = dY + 0.15f;
            
        }

     
       
    }
}
