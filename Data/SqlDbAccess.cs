using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class SqlDbAccess
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["Cerberus.TemplateEngineConnectionStringName"]].ConnectionString;

		public static SqlCommand CreateTextCommand()
		{
			var command = new SqlCommand();
			command.Connection = new SqlConnection(connectionString);
			return command;
		}

		public static SqlParameter AddParameter(SqlCommand command, string parameterName, SqlDbType type, object value, int size = 0)
		{
			var parameter = command.Parameters.Add(new SqlParameter(parameterName, type));

			parameter.Value = value;
			if (size > 0)
			{
				parameter.Size = size;
			}

			return parameter;
		}

		public static DataTable ExecuteSelect(SqlCommand command)
		{
			var result = new DataTable();

			using (command.Connection)
			{
				command.Connection.Open();
				using (var dataAdapter = new SqlDataAdapter(command))
				{
					dataAdapter.Fill(result);
				}
			}

			command.Connection.ConnectionString = connectionString;

			return result;
		}

		public static T ExecuteScalar<T>(SqlCommand command)
		{
			var result = default(T);

			using (command.Connection)
			{
				command.Connection.Open();
				result = (T)command.ExecuteScalar();
			}

			command.Connection.ConnectionString = connectionString;

			return result;
		}

		public static int ExecuteNonQuery(SqlCommand command)
		{
			var result = 0;

			using (command.Connection)
			{
				command.Connection.Open();
				result = command.ExecuteNonQuery();
			}

			command.Connection.ConnectionString = connectionString;

			return result;
		}
	}
}
