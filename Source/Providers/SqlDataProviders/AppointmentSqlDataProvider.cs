// <copyright file="AppointmentSqlDataProvider.cs" company="Engage Software">
// Engage: Booking
// Copyright (c) 2004-2009
// by Engage Software ( http://www.engagesoftware.com )
// </copyright>
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

namespace Engage.Dnn.Booking
{
    using System.Data;

    /// <summary>
    /// A SQL implementation of data access for the <see cref="Appointment"/> and related types
    /// </summary>
    public static class AppointmentSqlDataProvider
    {
        /// <summary>
        /// Gets a page of the appointments for a given <paramref name="moduleId"/>.
        /// </summary>
        /// <param name="moduleId">The ID of the module to which the appointments belong.</param>
        /// <param name="sortExpression">A comma-delimited list of the columns by which to sort.</param>
        /// <param name="pageSize">Size of the page, or <c>null</c> to retrieve all appointments.</param>
        /// <param name="pageIndex">Index of the page, or <c>null</c> to retrieve all appointments.</param>
        /// <returns>
        /// An <see cref="IDataReader"/> with two results; 
        /// the first being the total number of appointments for the module (as a single integer), 
        /// the second being the appointments.
        /// </returns>
        public static IDataReader GetAppointments(int moduleId, string sortExpression, int? pageSize, int? pageIndex)
        {
            return SqlDataProvider.Instance.ExecuteReader(
                    "GetAppointments",
                    Engage.Utility.CreateIntegerParam("@moduleId", moduleId),
                    sortExpression != null ? Engage.Utility.CreateVarcharParam("@sortExpression", sortExpression) : null,
                    Engage.Utility.CreateIntegerParam("@pageSize", pageSize),
                    Engage.Utility.CreateIntegerParam("@pageIndex", pageIndex));
        }

        /// <summary>
        /// Gets the appointment with the given <paramref name="appointmentId"/>.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to retrieve.</param>
        /// <returns>An <see cref="IDataReader"/> with the appointment record</returns>
        public static IDataReader GetAppointment(int appointmentId)
        {
            return SqlDataProvider.Instance.ExecuteReader("GetAppointment", Engage.Utility.CreateIntegerParam("@appointmentId", appointmentId));
        }

        /// <summary>
        /// Deletes the appointment with the given <paramref name="appointmentId"/>.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to delete.</param>
        public static void DeleteAppointment(int appointmentId)
        {
            SqlDataProvider.Instance.ExecuteNonQuery("DeleteAppointment", Engage.Utility.CreateIntegerParam("@Appointment", appointmentId));
        }

        /// <summary>
        /// Inserts the given <paramref name="appointment"/> into the ol' database.
        /// </summary>
        /// <param name="appointment">The appointment to insert.</param>
        /// <param name="revisingUser">The ID of the user inserting.</param>
        /// <returns>The ID of the new appointment record</returns>
        public static int InsertAppointment(Appointment appointment, int revisingUser)
        {
            return (int)SqlDataProvider.Instance.ExecuteScalar(
                "InsertAppointment",
                Engage.Utility.CreateIntegerParam("@appointmentTypeId", appointment.AppointmentTypeId),
                Engage.Utility.CreateIntegerParam("@moduleId", appointment.ModuleId),
                Engage.Utility.CreateVarcharParam("@title", appointment.Title),
                Engage.Utility.CreateTextParam("@description", appointment.Description),
                Engage.Utility.CreateTextParam("@notes", appointment.Notes),
                Engage.Utility.CreateVarcharParam("@address1", appointment.Address1),
                Engage.Utility.CreateVarcharParam("@address2", appointment.Address2),
                Engage.Utility.CreateVarcharParam("@city", appointment.City),
                Engage.Utility.CreateIntegerParam("@regionId", appointment.RegionId),
                Engage.Utility.CreateVarcharParam("@postalCode", appointment.PostalCode),
                Engage.Utility.CreateVarcharParam("@phone", appointment.Phone),
                Engage.Utility.CreateVarcharParam("@additionalAddressInfo", appointment.AdditionalAddressInfo),
                Engage.Utility.CreateVarcharParam("@contactStreet", appointment.ContactStreet),
                Engage.Utility.CreateVarcharParam("@contactPhone", appointment.ContactPhone),
                Engage.Utility.CreateVarcharParam("@requestorName", appointment.RequestorName),
                Engage.Utility.CreateVarcharParam("@requestorPhoneType", appointment.RequestorPhoneType),
                Engage.Utility.CreateVarcharParam("@requestorPhone", appointment.RequestorPhone),
                Engage.Utility.CreateVarcharParam("@requestorEmail", appointment.RequestorEmail),
                Engage.Utility.CreateVarcharParam("@requestorAltPhoneType", appointment.RequestorAltPhoneType),
                Engage.Utility.CreateVarcharParam("@requestorAltPhone", appointment.RequestorAltPhone),
                Engage.Utility.CreateDateTimeParam("@startDateTime", appointment.StartDateTime),
                Engage.Utility.CreateDateTimeParam("@endDateTime", appointment.EndDateTime),
                Engage.Utility.CreateIntegerParam("@numberOfParticipants", appointment.NumberOfParticipants),
                Engage.Utility.CreateVarcharParam("@participantGender", appointment.ParticipantGender),
                Engage.Utility.CreateCharParam("@participantFlag", appointment.ParticipantFlag),
                Engage.Utility.CreateTextParam("@participantInstructions", appointment.ParticipantInstructions),
                Engage.Utility.CreateIntegerParam("@numberOfSpecialParticipants", appointment.NumberOfSpecialParticipants),
                Engage.Utility.CreateBitParam("@accepted", appointment.IsAccepted),
                Engage.Utility.CreateIntegerParam("@revisingUser", revisingUser));
        }

        /// <summary>
        /// Updates the given <paramref name="appointment"/>'s record.
        /// </summary>
        /// <param name="appointment">The appointment to update.</param>
        /// <param name="revisingUser">The ID of the user making this update.</param>
        public static void UpdateAppointment(Appointment appointment, int revisingUser)
        {
            SqlDataProvider.Instance.ExecuteNonQuery(
                "UpdateAppointment",
                Engage.Utility.CreateIntegerParam("@appointmentId", appointment.AppointmentId),
                Engage.Utility.CreateIntegerParam("@appointmentTypeId", appointment.AppointmentTypeId),
                Engage.Utility.CreateVarcharParam("@title", appointment.Title),
                Engage.Utility.CreateTextParam("@description", appointment.Description),
                Engage.Utility.CreateTextParam("@notes", appointment.Notes),
                Engage.Utility.CreateVarcharParam("@address1", appointment.Address1),
                Engage.Utility.CreateVarcharParam("@address2", appointment.Address2),
                Engage.Utility.CreateVarcharParam("@city", appointment.City),
                Engage.Utility.CreateIntegerParam("@regionId", appointment.RegionId),
                Engage.Utility.CreateVarcharParam("@postalCode", appointment.PostalCode),
                Engage.Utility.CreateVarcharParam("@phone", appointment.Phone),
                Engage.Utility.CreateVarcharParam("@additionalAddressInfo", appointment.AdditionalAddressInfo),
                Engage.Utility.CreateVarcharParam("@contactStreet", appointment.ContactStreet),
                Engage.Utility.CreateVarcharParam("@contactPhone", appointment.ContactPhone),
                Engage.Utility.CreateVarcharParam("@requestorName", appointment.RequestorName),
                Engage.Utility.CreateVarcharParam("@requestorPhoneType", appointment.RequestorPhoneType),
                Engage.Utility.CreateVarcharParam("@requestorPhone", appointment.RequestorPhone),
                Engage.Utility.CreateVarcharParam("@requestorEmail", appointment.RequestorEmail),
                Engage.Utility.CreateVarcharParam("@requestorAltPhoneType", appointment.RequestorAltPhoneType),
                Engage.Utility.CreateVarcharParam("@requestorAltPhone", appointment.RequestorAltPhone),
                Engage.Utility.CreateDateTimeParam("@startDateTime", appointment.StartDateTime),
                Engage.Utility.CreateDateTimeParam("@endDateTime", appointment.EndDateTime),
                Engage.Utility.CreateIntegerParam("@numberOfParticipants", appointment.NumberOfParticipants),
                Engage.Utility.CreateVarcharParam("@participantGender", appointment.ParticipantGender),
                Engage.Utility.CreateCharParam("@participantFlag", appointment.ParticipantFlag),
                Engage.Utility.CreateTextParam("@participantInstructions", appointment.ParticipantInstructions),
                Engage.Utility.CreateIntegerParam("@numberOfSpecialParticipants", appointment.NumberOfSpecialParticipants),
                Engage.Utility.CreateBitParam("@accepted", appointment.IsAccepted),
                Engage.Utility.CreateIntegerParam("@revisingUser", revisingUser));
        }
    }
}