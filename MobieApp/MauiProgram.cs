using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;

#if __ANDROID__
    using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
namespace MobieApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                #if IOS || MACCATALYST
                    h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                #endif

                #if __ANDROID__
                   h.PlatformView.BackgroundTintList =
                        Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
                #endif

            });

            #if DEBUG
                    builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}