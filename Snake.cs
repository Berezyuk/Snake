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

namespace Snake
{
    internal class Snake
    {
        public float speed = 0.0001f;
        int counter = 0;
        public float size = 0f;
        public float flag = 0f;

       
        public List<float[]> x = new List<float[]> ();
        public List<float[]> y = new List<float[]> ();  
        public List<int> commands = new List<int> (); 
        
        public Snake()
        {
            x.Add(new float[] { -0.05f, 0.05f, 0.05f, -0.05f });
            y.Add(new float[] { -0.05f, -0.05f, 0.05f, 0.05f });
            x.Add(new float[] { -0.05f, 0.05f, 0.05f, -0.05f });
            y.Add(new float[] { -0.15f, -0.15f, -0.05f, -0.05f });
            commands.Add(0);
            commands.Add(0);
            
        }  

        public void Drawsnake()
        {
           
            for(int i = 0; i< x.Count ; i++)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(Color4.Blue);
                GL.Vertex2(x[i][0], y[i][0]);
                GL.Vertex2(x[i][1], y[i][1]);
                GL.Vertex2(x[i][2], y[i][2] + size);
                GL.Vertex2(x[i][3], y[i][3] + size);
                GL.End();
            }
            
       
        }
        public void Left(int i , ref float flag)
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

            if (flag > 1.0f)
            {
                if (commands.Count == 2)
                {
                       commands[1] = commands[0];
                }
                else if (commands.Count > 2)
                {
                    for (int i = 1; i < commands.Count - 1; i++)
                    {
                        commands[i + 1] = commands[i];
                    }
                }
            }

            if (commands[0] != side)
            {
                flag = 0f;
            }

            commands[0] = side;



            for (int i = 0; i<commands.Count; i++)
            {
                switch (commands[i])
                {
                    case 0:
                        Up(i );
                        
                        break;
                    case 1:
                        Down(i);
                        break;
                    case 2:
                        Right(i);
                        break;
                    case 3:
                        Left(i, ref flag);
                        break;

                }
                Changeside(i);
            }
            counter++;
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
            
                    y[j][0] = 1.0f -0.1f ;
                    y[j][1] = 1.0f -0.1f;
                    y[j][2] = 1.0f ;
                    y[j][3] = 1.0f;
                
            
            }
            else if (x[j][1] > 1.0f)
            {
               
                    x[j][0] = -1.0f ;
                    x[j][1] = -1.0f + 0.1f;
                    x[j][2] = -1.0f + 0.1f;
                    x[j][3] = -1.0f;
                
            }
            else if (x[j][1] < -1.0f)
            {
                
                    x[j][0] = 1.0f - 0.1f;
                    x[j][1] = 1.0f ;
                    x[j][2] = 1.0f ;
                    x[j][3] = 1.0f - 0.1f;

                
            }
        }
       
    }
}
