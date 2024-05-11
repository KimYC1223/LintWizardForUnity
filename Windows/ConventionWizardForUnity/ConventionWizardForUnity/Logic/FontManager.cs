using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace ConventionWizardForUnity
{
    ///==========================================================================================================================
    ///
    ///  Font Manager
    ///  ------------------------------------------------------------------------------------------------------------------------
    ///  <summary>
    ///  Application UI에서 사용 가능한 Font를 불러오는 매니저
    ///  </summary>
    ///
    ///==========================================================================================================================
    public class FontManager
    {
        ///======================================================================================================================
        /// PRIVATE STATIC 필드
        ///======================================================================================================================
        private static FontManager instance = new FontManager();                // 해당 클래스의 인스턴스. 시작하자마자 초기화

        /// ======================================================================================================================
        /// PUBLIC STATIC 필드
        ///======================================================================================================================
        /// <summary>
        /// 사용할 폰트 모음
        /// </summary>
        public static FontFamily[] FontFamilys => instance.PrivateFont.Families;

        ///======================================================================================================================
        /// PUBLIC STATIC 필드
        ///======================================================================================================================
        public PrivateFontCollection PrivateFont = new PrivateFontCollection(); // 사용할 추가 폰트

        ///======================================================================================================================
        /// <summary>
        /// 기본 생성자
        /// </summary>
        ///======================================================================================================================
        public FontManager()
        {
            AddFontFromMemory();
        }

        ///======================================================================================================================
        /// Resource에 있는 폰트를 메모리에 올리는 메서드
        ///======================================================================================================================
        private void AddFontFromMemory()
        {
            var fonts = new List<byte[]>
            {
                Properties.Resources.D2Coding
            };

            foreach (byte[] font in fonts)
            {
                var fontBuffer = Marshal.AllocCoTaskMem(font.Length);
                Marshal.Copy(font, 0, fontBuffer, font.Length);
                PrivateFont.AddMemoryFont(fontBuffer, font.Length);

                Marshal.FreeHGlobal(fontBuffer);                        //메모리 해제
            }
        }
    }
}