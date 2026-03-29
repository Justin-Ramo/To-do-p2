using Microsoft.Maui.Controls;
using System;
using System.Text.Json;

namespace todo;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        var firstName = FirstNameEntry.Text;
        var lastName = LastNameEntry.Text;
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        var result = await Services.ApiService.SignUp(firstName, lastName, email, password);
        var status = result.RootElement.GetProperty("status").GetString();
        var message = result.RootElement.GetProperty("message").GetString();

        MessageLabel.Text = message;

        if (status == "success")
        {
            await DisplayAlertAsync("Success", "Account created! Please log in.", "OK");
            await Navigation.PushAsync(new SignInPage());
        }
    }

    private async void GoToSignIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignInPage());
    }
}