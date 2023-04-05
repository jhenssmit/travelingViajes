using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using travelingViajes.Models;
using Xamarin.Forms.Database.Models;

namespace travelingViajes.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Usuarios>().Wait();
            db.CreateTableAsync<ServiciosVuelos>().Wait();
            db.CreateTableAsync<Admin>().Wait();
            db.CreateTableAsync<Reserva>().Wait();
        }

        //Registrar Usuario
        public Task<int> SaveUsuarioAsync(Usuarios users)
        {
            if (users.IdUsuario == 0)
            {
                return db.InsertAsync(users);
            }
            else
            {
                return null;
            }
        }
        //Registrar Admin
        public Task<int> SaveAdminAsync(Admin admins)
        {
            {
                if (admins.IdAdmin == 0)
                {
                    return db.InsertAsync(admins);
                }
                else
                {
                    return null;
                }
            }


        }
        //Verificación de Credenciales
        public Task<bool> VerifyAdminCredentialsAsync(string usuario, string contrasena)
        {
            return db.Table<Admin>().Where(a => a.Usuario == usuario && a.Contraseña == contrasena).CountAsync().ContinueWith(task =>
            {
                return task.Result > 0;
            });
        }
        // Lista de reservas
        public async Task<List<Reserva>> GetReservasByUserIdAsync(string userId)
        {
            return await db.Table<Reserva>()
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
        //Ver lista de Admin
        public Task<List<Admin>> GetAdminAsync()
        {
            return db.Table<Admin>().ToListAsync();
        }
        public Task<Admin> GetAdminById(int IdAdmin)
        {
            return db.Table<Admin>().Where(a => a.IdAdmin == IdAdmin).FirstOrDefaultAsync();
        }
        //Ver lista de Usuarios
        public Task<List<Usuarios>> GetUsuarioAsync()
        {
            return db.Table<Usuarios>().ToListAsync();
        }
        public Task<Usuarios> GetUsuarioById(int IdUsuario)
        {
            return db.Table<Usuarios>().Where(a => a.IdUsuario == IdUsuario).FirstOrDefaultAsync();
        }
        //obtener el vuelo por el id
        public Task<ServiciosVuelos> GetVueloById(int IdVuelo)
        {
            return db.Table<ServiciosVuelos>().Where(a => a.IdVuelos == IdVuelo).FirstOrDefaultAsync();
        }

        //reservar el vuelo
        public async Task<bool> SaveReservaAsync(ServiciosVuelos vuelo, string userId)
        {
            try
            {
                var reserva = new Reserva
                {
                    UserId = userId,
                    IdVuelos = vuelo.IdVuelos,
                };

                await db.InsertAsync(reserva);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al guardar la reserva: {ex.Message}");
                return false;
            }
        }

        //Verificación de Usuarios Credenciales
        public Task<bool> VerifyUsuariosCredentialsAsync(string correo, string contrasena)
        {
            return db.Table<Usuarios>().Where(a => a.Correo == correo && a.Contrasena == contrasena).FirstOrDefaultAsync().ContinueWith(task =>
            {
                var User = task.Result;
                if(User != null)
                {
                    Session.UserName = User.Correo;
                    Session.UserId = User.IdUsuario;
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }


        //Registrar Vuelos
        public Task<int> SaveVuelosAsync(ServiciosVuelos Vuelos) {
            {
                if (Vuelos.IdVuelos != 0)
                {
                    return db.UpdateAsync(Vuelos);
                }
                else
                {
                    return db.InsertAsync(Vuelos);
                }
            }
        

        }
        //Eliminar Vuelos
        public Task<int> DeleteVuelo(ServiciosVuelos Vuelos)
        {
            return db.DeleteAsync(Vuelos);
        }
        //Ver lista de Vuelos
        public Task<List<ServiciosVuelos>> GetServiciosVueloAsync()
        {
            return db.Table<ServiciosVuelos>().ToListAsync();
        }
        public Task<ServiciosVuelos> GetServiciosVuelosByIdAsync(int IdVuelos)
        {
            return db.Table<ServiciosVuelos>().Where(a => a.IdVuelos == IdVuelos).FirstOrDefaultAsync();
        }
        
        

    }
    
    
}
