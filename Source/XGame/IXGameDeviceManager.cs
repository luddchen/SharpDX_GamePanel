using System;

namespace XGame
{

    public interface IXGameDeviceManager : IDisposable
    {
        //readonly XGamePlatform Platform;

        void CreateDevice();

        bool BeginDraw();

        void EndDraw();

        void Present();

    }

}
