using System;
using System.Collections.Generic;
using System.Text;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.Responses
{
	public class AirfieldSaveResponse: BaseResponse
	{
		public AirfieldShallowDTO AirfieldDTO { get; set; }

		public AirfieldSaveResponse(AirfieldShallowDTO airfieldDTO, bool success, string message) : base(success, message) {
			AirfieldDTO = airfieldDTO;
		}

		public AirfieldSaveResponse(AirfieldShallowDTO airfieldDTO) : this(airfieldDTO, true, "") { }
		public AirfieldSaveResponse(string message) : this(null, false, message) { }
	}
}
