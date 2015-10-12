﻿using System;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace jcW3CLOUD.UWP {
    sealed partial class App {
        public App() {
            InitializeComponent();
            Suspending += OnSuspending;
        }
        
        protected override void OnLaunched(LaunchActivatedEventArgs e) {
            var rootFrame = Window.Current.Content as Frame;
            
            if (rootFrame == null) {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null) {
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            
            Window.Current.Activate();
        }
        
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e) {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
        
        private void OnSuspending(object sender, SuspendingEventArgs e) {
            var deferral = e.SuspendingOperation.GetDeferral();

            deferral.Complete();
        }
    }
}