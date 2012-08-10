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

using System.IO;
using Sharpen;

namespace Couchbase.TouchDB
{
	public class TDAttachment
	{
		private InputStream contentStream;

		private string contentType;

		public TDAttachment()
		{
		}

		public TDAttachment(InputStream contentStream, string contentType)
		{
			this.contentStream = contentStream;
			this.contentType = contentType;
		}

		public virtual InputStream GetContentStream()
		{
			return contentStream;
		}

		public virtual void SetContentStream(InputStream contentStream)
		{
			this.contentStream = contentStream;
		}

		public virtual string GetContentType()
		{
			return contentType;
		}

		public virtual void SetContentType(string contentType)
		{
			this.contentType = contentType;
		}
	}
}
