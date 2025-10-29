using System;
using System.Collections.Generic;

namespace CubeFlux.Core
{
    /// Ligero y suficiente para prototipo. No abuses: registra singletones “servicio”.
    public static class ServiceLocator
    {

        //Corazon del Service Locator. 
        // Diccionario estático y de solo lectura.
        // La referencia no puede cambiar pero su contenido sí.
        private static readonly Dictionary<Type, object> _services = new();


        //Registra una instancia o servicio en la guía telefonica.
        public static void Register<T>(T instance) where T : class
        {
            _services[typeof(T)] = instance ?? throw new ArgumentNullException(nameof(instance));
        }


        //Obtiene una instancia o servicio de la guía telefonica.
        public static T Get<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var o)) return (T)o;
            throw new InvalidOperationException($"Service not found: {typeof(T).Name}");
        }
        //Esta es la versión "segura" de Get<T>. En lugar de fallar si el servicio no existe, te permite comprobar si está disponible.
        public static bool TryGet<T>(out T instance) where T : class
        {
            if (_services.TryGetValue(typeof(T), out var o)) { instance = (T)o; return true; }
            instance = null!;
            return false;
        }
        //Un método de utilidad muy práctico. Borra todos los servicios registrados.
        public static void Clear() => _services.Clear();
    }
}
