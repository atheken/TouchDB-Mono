/**
 * Original iOS version by  Jens Alfke
 * Ported Android version by Marty Schoch
 * C# Port by John Zablocki
 *
 * Copyright (c) 2012 Couchbase, Inc. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using System.Text;
using Sharpen;

namespace Couchbase.TouchDB
{
	/// <summary>Key identifying a data blob.</summary>
	/// <remarks>Key identifying a data blob. This happens to be a SHA-1 digest.</remarks>
	public class TDBlobKey
	{
		private byte[] bytes;

		public TDBlobKey()
		{
		}

		public TDBlobKey(byte[] bytes)
		{
			this.bytes = bytes;
		}

		public virtual void SetBytes(byte[] bytes)
		{
			this.bytes = bytes;
		}

		public virtual byte[] GetBytes()
		{
			return bytes;
		}

		public static string ConvertToHex(byte[] data)
		{
			StringBuilder buf = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				int halfbyte = (data[i] >> 4) & unchecked((int)(0x0F));
				int two_halfs = 0;
				do
				{
					if ((0 <= halfbyte) && (halfbyte <= 9))
					{
						buf.Append((char)('0' + halfbyte));
					}
					else
					{
						buf.Append((char)('a' + (halfbyte - 10)));
					}
					halfbyte = data[i] & unchecked((int)(0x0F));
				}
				while (two_halfs++ < 1);
			}
			return buf.ToString();
		}

		public static byte[] ConvertFromHex(string s)
		{
			int len = s.Length;
			byte[] data = new byte[len / 2];
			for (int i = 0; i < len; i += 2)
			{
				data[i / 2] = unchecked((byte)((char.Digit(s[i], 16) << 4) + char.Digit(s[i + 1], 
					16)));
			}
			return data;
		}

		public override bool Equals(object o)
		{
			if (!(o is Couchbase.TouchDB.TDBlobKey))
			{
				return false;
			}
			Couchbase.TouchDB.TDBlobKey oBlobKey = (Couchbase.TouchDB.TDBlobKey)o;
			return Arrays.Equals(GetBytes(), oBlobKey.GetBytes());
		}

		public override int GetHashCode()
		{
			return Arrays.HashCode(bytes);
		}

		public override string ToString()
		{
			return Couchbase.TouchDB.TDBlobKey.ConvertToHex(bytes);
		}
	}
}
