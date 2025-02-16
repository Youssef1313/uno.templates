//-:cnd:noEmit
namespace MyExtensionsApp._1;

//+:cnd:noEmit
#if mauiEmbedding
public class App : EmbeddingApplication
#else
public class App : Application
#endif
//-:cnd:noEmit
{
    protected Window? MainWindow { get; private set; }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
#if NET6_0_OR_GREATER && WINDOWS && !HAS_UNO
        MainWindow = new Window();
#else
        MainWindow = Microsoft.UI.Xaml.Window.Current;
#endif

//+:cnd:noEmit
#if mauiEmbedding
//-:cnd:noEmit
#if MAUI_EMBEDDING
        this.UseMauiEmbedding<MauiControls.App>(MainWindow, maui => maui
                    .UseMauiControls());
#endif
//+:cnd:noEmit
#endif
//-:cnd:noEmit

        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (MainWindow.Content is not Frame rootFrame)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();

            // Place the frame in the current Window
            MainWindow.Content = rootFrame;

            rootFrame.NavigationFailed += OnNavigationFailed;
        }

        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(MainPage), args.Arguments);
        }

        // Ensure the current window is active
        MainWindow.Activate();
    }

    /// <summary>
    /// Invoked when Navigation to a certain page fails
    /// </summary>
    /// <param name="sender">The Frame which failed navigation</param>
    /// <param name="e">Details about the navigation failure</param>
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new InvalidOperationException($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");
    }
}
