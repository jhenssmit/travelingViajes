using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using travelingViajes.Models;

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
        // Sesión Activa Admin
        
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
        //Verificación de Usuarios Credenciales
        public Task<bool> VerifyUsuariosCredentialsAsync(string correo, string contrasena)
        {
            return db.Table<Usuarios>().Where(a => a.Correo == correo && a.Contrasena == contrasena).CountAsync().ContinueWith(task =>
            {
                return task.Result > 0;
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
