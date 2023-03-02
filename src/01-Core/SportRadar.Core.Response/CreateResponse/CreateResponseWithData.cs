using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeppeling.Framework.Abstactions.Response;

namespace SportRadar.Core.Response.CreateResponse
{
    public static class CreateResponseWithData<T> where T : class
    {
        /// <summary>
        /// Returns the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public static async Task<ResponseDTO<T>> Return(T entity)
        {

            string message = string.Empty;
            if (entity != null)
                message = GetResponseCode.GetDescription(Fixture.Success);
            else
                message = GetResponseCode.GetDescription(Fixture.NotFound);
            ResponseDTO<T> response = new ResponseDTO<T>
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    ResponseDate = DateTime.Now,
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = entity == null ? Fixture.Failed : Fixture.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }

        /// <summary>
        /// Returns the specified entity.
        /// </summary>
        /// <param name="entity">if set to <c>true</c> [entity].</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public static async Task<ResponseDTO> Return(bool entity)
        {

            string message = string.Empty;
            if (entity != null)
                message = GetResponseCode.GetDescription(Fixture.Success);
            else
                message = GetResponseCode.GetDescription(Fixture.NotFound);
            ResponseDTO response = new ResponseDTO
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    ResponseDate = DateTime.Now,
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = entity == null ? Fixture.Failed : Fixture.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }

        /// <summary>
        /// Returns the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public static async Task<ResponseListDTO<T>> Return(IEnumerable<T> entity)
        {
            string message = string.Empty;
            if (entity.Count() > 0)
                message = GetResponseCode.GetDescription(Fixture.Success);
            else
                message = GetResponseCode.GetDescription(Fixture.NotFound);

            ResponseListDTO<T> response = new ResponseListDTO<T>
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    ResponseDate = DateTime.Now,
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = entity == null ? Fixture.NotFound : Fixture.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }
    }
}
