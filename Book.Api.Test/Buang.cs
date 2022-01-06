using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Api.Test
{
	public class Buang : IDisposable
	{
		public string _managed = "string";
		public string _unmanaged = "unmanaged";
		private bool _isDisposed = false;

		~Buang()
		{
			Disposing(false);
		}

		public void Dispose()
		{
			Disposing(true);
			GC.SuppressFinalize(this);

		}

		public virtual void Disposing(bool disposing)
		{
			if (_isDisposed)
			{
				if (disposing)
				{
					_managed = null;
				}

				_unmanaged = null;

				_isDisposed = true;
			}


		}
	}

	public  class Inher : Buang
	{
		public string _managed2 = "string";
		public string _unmanaged2 = "unmanaged";
		private bool _isDisposed = false;

		public override void Disposing(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing)
				{
					_managed2 = null;
				}

				_unmanaged2 = null;

				_isDisposed = true;
			}

			base.Disposing(disposing);
		}

	}
}
