using System;
using UnityEngine;

namespace CubeFlux.Core
{
    public static class GameLayers
    {
        // Ajusta en Project Settings > Tags and Layers, luego asigna aquí por nombre si quieres:
        public static readonly int Player = LayerMask.NameToLayer("Player");
        public static readonly int Collectible = LayerMask.NameToLayer("Collectible");
    }
}
