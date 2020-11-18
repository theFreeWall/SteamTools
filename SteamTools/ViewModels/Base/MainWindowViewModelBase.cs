﻿using Livet;
using MetroTrilithon.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroRadiance.UI;
using MetroTrilithon.Lifetime;
using Livet.Messaging;
using SteamTools.Models;
using System.ComponentModel;

namespace SteamTools.ViewModels
{
    public abstract class MainWindowViewModelBase: WindowViewModel
    {

		#region StatusBar 变更通知

		private ViewModel _StatusBar;

		public ViewModel StatusBar
		{
			get { return this._StatusBar; }
			set
			{
				if (this._StatusBar != value)
				{
					this._StatusBar = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		protected MainWindowViewModelBase()
		{
			this.Title = ProductInfo.Title;
			this.CanClose = false;

			//((INotifyPropertyChanged)App.Instance).Subscribe(nameof(App.State), this.RaiseCanCloseChanged).AddTo(this);
			//KanColleClient.Current.Subscribe(nameof(KanColleClient.IsInSortie), this.RaiseCanCloseChanged).AddTo(this);
			//GeneralSettings.ExitConfirmationType.Subscribe(_ => this.RaiseCanCloseChanged());
		}


		/// <summary>
		/// 使用<see cref ="TransitionMode.NewOrActive" />从当前窗口转换到指定窗口。
		/// </summary>
		public void Transition(ViewModel viewModel, Type windowType)
		{
			this.Transition(viewModel, windowType, TransitionMode.NewOrActive, false);
		}

		/// <summary>
		/// 在当前窗口中显示对话框。
		/// </summary>
		public void Dialog(ViewModel viewModel, Type windowType)
		{
			this.Transition(viewModel, windowType, TransitionMode.Modal, true);
		}

		protected override void CloseCanceledCallbackCore()
		{
			//var dialog = new DialogViewModel { Title = "終了確認", };

			//this.Dialog(dialog, typeof(ExitDialog));

			//if (dialog.DialogResult)
			//{
			//	this.CanClose = true;
			//	this.InvokeOnUIDispatcher(this.Close);
			//}
		}

		protected void RaiseCanCloseChanged()
		{
			this.RaisePropertyChanged(nameof(this.CanClose));
		}

	}
}