﻿/**
@Name: QueryStringTool
@Author: HobisJung
@Date: 2015-10-04
@Comment:
{
}
==================================================================================================== */
package
{
	public class QueryStringTool
	{
		public function QueryStringTool() {}

		// :: pObj -> qStr
		public static function convert_qStr(pObj:Object):String
		{
			var t_rv:String = null;

			for (var t_p:String in pObj)
			{
				if (t_rv == null)
					t_rv = '';

				var t_valStr:String = pObj[t_p];
				t_valStr = encodeURIComponent(t_valStr);
				var t_addStr:String = t_p + '=' + t_valStr + '&';
				t_rv += t_addStr;
			}

			if (t_rv != null)
				t_rv = t_rv.substr(0, t_rv.length - 1);

			return t_rv;
		}

		// :: qStr -> pObj
		public static function convert_pObj(qStr:String):Object
		{
			var t_rv:Object = null;

			var t_nvss:Array = qStr.split('&');
			if (t_nvss != null)
			{
				for each (var t_nvs:String in t_nvss)
				{
					if (t_rv == null)
						t_rv = {};

					var t_pis:Array = t_nvs.split('=');
					var t_pin:String = t_pis[0];
					var t_piv:String = decodeURIComponent(t_pis[1]);
					t_rv[t_pin] = t_piv;
				}
			}

			return t_rv;
		}
	}
}
