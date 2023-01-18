using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.World.Shared.Data.Enums
{
	public enum FileType
	{
		/// <summary>
		/// Word文档,包括docx;xlsx
		/// </summary>
		Word = 0x00,
		/// <summary>
		/// PDF文档
		/// </summary>
		Pdf = 0x01,
		/// <summary>
		/// 图片文档
		/// </summary>
		Image = 0x02,
		/// <summary>
		/// 文本文档,支持所有UTF-8打开的文本文件,包括代码文件
		/// </summary>
		Text = 0x03,
		/// <summary>
		/// 其他
		/// </summary>
		Other = 0x04
		
	}
}
