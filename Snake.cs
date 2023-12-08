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
using System.Security.Cryptography;

namespace Snake
{
    internal class Snake
    {
        public float speed = 0.1f;
        public float size = 0f;
        public int iter = 0;
     

        public List<float[]> x = new List<float[]>();
        public List<float[]> y = new List<float[]>();
        public List<int> commands = new List<int>();

        public Snake()
        {
            x.Add(new float[] { -0.05f, 0.05f, 0.05f, -0.05f });
            y.Add(new float[] { -0.05f, -0.05f, 0.05f, 0.05f });
            x.Add(new float[] { -0.05f, 0.05f, 0.05f, -0.05f });
            y.Add(new float[] { -0.15f, -0.15f, -0.05f, -0.05f });
            x.Add(new float[] { -0.05f, 0.05f, 0.05f, -0.05f });
            y.Add(new float[] { -0.25f, -0.25f, -0.15f, -0.15f });
           


            commands.Add(0);
            commands.Add(0);
            commands.Add(0);
           

        }

        public void Drawsnake()
        {

            for (int i = 0; i < x.Count; i++)
            {
                GL.Begin(PrimitiveType.Polygon);
                GL.Color4(Color4.Cyan);
                GL.Vertex2(x[i][0], y[i][0]);
                GL.Vertex2(x[i][1], y[i][1]);
                GL.Vertex2(x[i][2], y[i][2]);
                GL.Vertex2(x[i][3], y[i][3]);
                GL.End();
               
            }


        }
        public void Left(int i)
        {

            x[i][0] -= speed;
            x[i][1] -= speed;
            x[i][2] -= speed;
            x[i][3] -= speed;


        }
        public void Right(int i)
        {

            x[i][0] += speed;
            x[i][1] += speed;
            x[i][2] += speed;
            x[i][3] += speed;

        }
        public void Down(int i)
        {

            y[i][0] -= speed;
            y[i][1] -= speed;
            y[i][2] -= speed;
            y[i][3] -= speed;

        }
        public void Up(int i)
        {

            y[i][0] += speed;
            y[i][1] += speed;
            y[i][2] += speed;
            y[i][3] += speed;


        }
        public void Move(int side)
        {
            List<int> tempCommands = new List<int> { };

            for (int i = 0; i < commands.Count - 1; i++)
            {
                tempCommands.Add(commands[i]);
            }

            for (int i = 1; i < commands.Count; i++)
            {
                commands[i] = tempCommands[i - 1];
            }

            commands[0] = side;

            for (int i = 0; i < commands.Count; i++)
            {
                switch (commands[i])
                {
                    case 0:
                        Up(i);
                        break;
                    case 1:
                        Down(i);
                        break;
                    case 2:
                        Right(i);
                        break;
                    case 3:
                        Left(i);
                        break;

                }
                Changeside(i);
            }

          Thread.Sleep(100);
        }

        public void Changeside(int j)
        {

            if (y[j][2] > 1.0f)
            {
                y[j][0] = -1.0f;
                y[j][1] = -1.0f;
                y[j][2] = -1.0f + 0.1f;
                y[j][3] = -1.0f + 0.1f;


            }
            else if (y[j][1] < -1.0f)
            {

                y[j][0] = 1.0f - 0.1f;
                y[j][1] = 1.0f - 0.1f;
                y[j][2] = 1.0f;
                y[j][3] = 1.0f;


            }
            else if (x[j][1] > 1.0f)
            {

                x[j][0] = -1.0f;
                x[j][1] = -1.0f + 0.1f;
                x[j][2] = -1.0f + 0.1f;
                x[j][3] = -1.0f;

            }
            else if (x[j][1] < -1.0f)
            {

                x[j][0] = 1.0f - 0.1f;
                x[j][1] = 1.0f;
                x[j][2] = 1.0f;
                x[j][3] = 1.0f - 0.1f;


            }
        }

        public void Grow()
        {
            float x0 = x[x.Count - 1][0];
            float x1 = x[x.Count - 1][1];
            float x2 = x[x.Count - 1][2];
            float x3 = x[x.Count - 1][3];

            float y0 = y[y.Count - 1][0];
            float y1 = y[y.Count - 1][1];
            float y2 = y[y.Count - 1][2];
            float y3 = y[y.Count - 1][3];

            switch(commands[commands.Count - 1])
            {
                case 0:// 
                    x.Add(new float[] { x0, x1, x2, x3 });                             
                    y.Add(new float[] { y0 - 0.1f, y1 - 0.1f, y1 , y0 }); //y2,y3
                   
                    break;
                case 1:
                    x.Add(new float[] { x0, x1, x2, x3 });
                    y.Add(new float[] { y0 + 0.1f, y1 + 0.1f, y1 , y0 });//y2,y3
                   
                    break;
                case 2:
                    x.Add(new float[] { x0 - 0.1f, x1 - 0.1f, x1, x0});
                    y.Add(new float[] { y0, y1, y2, y3 });
                   
                    break;
                case 3:
                    x.Add(new float[] { x0 + 0.1f, x1 + 0.1f, x1, x0});
                    y.Add(new float[] { y0, y1, y2, y3 });
                    
                    break;

            }

            commands.Add(commands[commands.Count - 1]);
           
        }

    }
}

