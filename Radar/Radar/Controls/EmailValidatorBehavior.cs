using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Controls
{
	public class EmailValidatorBehavior : Behavior<Entry>
	{
		const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

		static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidatorBehavior), false);

		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

		static readonly BindablePropertyKey ErrorMessagePropertyKey = BindableProperty.CreateReadOnly("sucess", typeof(int), typeof(EmailValidatorBehavior), 0);

		public static BindableProperty ErrorMessageProperty = ErrorMessagePropertyKey.BindableProperty;


		static readonly BindablePropertyKey SmrdayKey = BindableProperty.CreateReadOnly("Smrda", typeof(int), typeof(EmailValidatorBehavior), 1);

		public static readonly BindableProperty SmrdaProperty = SmrdayKey.BindableProperty;


		static readonly BindablePropertyKey ImageSourcePropertyKey = BindableProperty.CreateReadOnly("ImageSource", typeof(string), typeof(EmailValidatorBehavior), "");

		public static readonly BindableProperty ImageSourceProperty = ImageSourcePropertyKey.BindableProperty;

		public string ImageSource
		{
			get { return (string)base.GetValue(ImageSourceProperty); }
			private set { base.SetValue(ImageSourcePropertyKey, value); }
		}

		public bool IsValid
		{
			get { return (bool)base.GetValue(IsValidProperty); }
			private set { base.SetValue(IsValidPropertyKey, value); }
		}
		public int Smrda
		{
			get { return (int)base.GetValue(SmrdaProperty); }
			private set { base.SetValue(SmrdayKey, value); }

		}

		//public int ErrorMessage
		//{
		//	get { return (int)GetValue(ErrorMessageProperty); }

		//	set { SetValue(ErrorMessageProperty, value); }
		//}


		void HandleTextChanged(object sender, TextChangedEventArgs e)
		{


			IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
			((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
			ImageSource = IsValid ? "success.png" : "error.png";

			//if (IsValid == true)
			//{
			//	ErrorMessage = 1;
			//}
			//else {
			//	ErrorMessage = 0;
			//}

			//if (String.IsNullOrEmpty(e.OldTextValue))
			//	Smrda = 0;
			//else
			//{
			//	Smrda = 1;

				//ErrorMessage = "Please enter email address";
			//	return;
			//}
			//if (!IsValid)
				//ErrorMessage = "Please enter valid email address";
			//else
				//ErrorMessage = "";

		}


		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;
		}
		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= HandleTextChanged;
		}
	}
}