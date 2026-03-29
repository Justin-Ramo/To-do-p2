using Microsoft.Maui.Controls;
using System;
using System.Text.Json;

namespace todo;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
    }

    private async void SignInButton_Clicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        var result = await Services.ApiService.SignIn(email, password);
        var status = result.RootElement.GetProperty("status").GetString();
        var message = result.RootElement.GetProperty("message").GetString();

        MessageLabel.Text = message;

        if (status == "success")
        {
            await DisplayAlertAsync("Success", "Login successful!", "OK");
            await Navigation.PushAsync(new ToDoPage());
         }    
    }

    private async void GoToSignUp_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }
}