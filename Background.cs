using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;


namespace Snake
{
    internal class Background
    {
        public Color4 maskColor = Color4.White;
        private float[,] coordinates =
        {
            {-1, 1, 1, -1},
            {-1, -1, 1, 1}
        };

        public Background()
        {

        }

        public void DrawBackground(int textureId)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);
            GL.BindTexture(TextureTarget.Texture2D, textureId);

            GL.Color4(maskColor);

            Draw(
                new float[,] { { 0f, 1f, 1f, 0f }, { 1f, 1f, 0f, 0f } },
                coordinates
            );
        }
        public void Draw(float[,] texCoordinates, float[,] vertexCoordinates)
        {
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(texCoordinates[0, 0], texCoordinates[1, 0]);
            GL.Vertex2(vertexCoordinates[0, 0], vertexCoordinates[1, 0]);

            GL.TexCoord2(texCoordinates[0, 1], texCoordinates[1, 1]);
            GL.Vertex2(vertexCoordinates[0, 1], vertexCoordinates[1, 1]);

            GL.TexCoord2(texCoordinates[0, 2], texCoordinates[1, 2]);
            GL.Vertex2(vertexCoordinates[0, 2], vertexCoordinates[1, 2]);

            GL.TexCoord2(texCoordinates[0, 3], texCoordinates[1, 3]);
            GL.Vertex2(vertexCoordinates[0, 3], vertexCoordinates[1, 3]);

            GL.End();
        }
    }
}
