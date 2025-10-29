using System;
using System.Collections.Generic;

namespace CubeFlux.Core
{
    public interface IGameEvent { }

    public static class EventBus
    {

        //Diccionario de suscriptores por tipo de evento
        private static readonly Dictionary<Type, List<Delegate>> _subs = new();
        //Métodos para suscribirse, desuscribirse y publicar eventos
        public static void Subscribe<T>(Action<T> handler) where T : IGameEvent
        {
            var t = typeof(T);
            if (!_subs.TryGetValue(t, out var list)) { list = new List<Delegate>(); _subs[t] = list; }
            list.Add(handler);
        }
        
        public static void Unsubscribe<T>(Action<T> handler) where T : IGameEvent
        {
            var t = typeof(T);
            if (_subs.TryGetValue(t, out var list)) list.Remove(handler);
        }
        //Publica un evento a todos los suscriptores registrados para ese tipo de evento
        public static void Publish<T>(T evt) where T : IGameEvent
        {
            var t = typeof(T);
            if (_subs.TryGetValue(t, out var list))
            {
                // snapshot para evitar modificación durante iteración
                var copy = list.ToArray();
                for (int i = 0; i < copy.Length; i++)
                    (copy[i] as Action<T>)?.Invoke(evt);
            }
        }
        //Borra todos los subscriptores registrados
        public static void Clear() => _subs.Clear();
    }
}
