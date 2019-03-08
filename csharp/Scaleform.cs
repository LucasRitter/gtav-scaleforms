using System;

namespace LucasRitter.Scaleforms
{
    public abstract class BaseScaleform
    {
        protected int _handle;
        public int Handle => _handle;

        protected ScaleformType _type;

        /// <summary>
        /// Calls a function on the current Scaleform.
        /// </summary>
        /// <param name="function">The name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        public abstract void CallFunction(string function, params object[] parameters);
        /// <summary>
        /// Calls a function on the current Scaleform and gets a return value.
        /// </summary>
        /// <param name="function">The name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The return value of the Scaleform function.</returns>
        public abstract bool CallFunctionBool(string function, params object[] parameters);
        
        /// <summary>
        /// Calls a function on the current Scaleform and gets a return value.
        /// </summary>
        /// <param name="function">The name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The return value of the Scaleform function.</returns>
        public abstract int CallFunctionInt(string function, params object[] parameters);
        
        /// <summary>
        /// Pushes Scaleform parameters to the call stack.
        /// </summary>
        /// <param name="parameters">The parameters that need to be pushed.</param>
        /// <exception cref="ArgumentException"></exception>
        protected void PushParameters(params object[] parameters)
        {
            foreach (var param in parameters)
            {
                switch (param)
                {
                    // Numerics
                    case bool pBool:
                        Natives.Graphics.PushScaleformMovieParameterBool(pBool);
                        break;
                    case byte pByte:
                        Natives.Graphics.PushScaleformMovieParameterInt(pByte);
                        break;
                    case int pInt:
                        Natives.Graphics.PushScaleformMovieParameterInt(pInt);
                        break;
                    case float pFloat:
                        Natives.Graphics.PushScaleformMovieParameterFloat(pFloat);
                        break;
                    case double pDouble:
                        Natives.Graphics.PushScaleformMovieParameterFloat((float) pDouble);
                        break;
                    // Text
                    case string pString:
                        Natives.Graphics.PushScaleformMovieParameterString(pString);
                        break;
                    case char pChar:
                        Natives.Graphics.PushScaleformMovieParameterString(pChar.ToString());
                        break;
                    // Todo: Add texture dictionaries as a parameter.
                    // Todo: Add localized text as a parameter.
                    default:
                        throw new ArgumentException($"Unknown argument type '{param.GetType()}' passed to {this._type} scaleform {this._handle}.");
                }
            }
        }
    }
    
    // Todo: Add comments.
    /// <summary>
    /// Scaleform.
    /// </summary>
    public class Scaleform : BaseScaleform
    {
        protected string _id;
        
        public Scaleform(int handle, ScaleformType type = ScaleformType.Generic)
        {
            this._handle = handle;
            this._type = type;
        }

        public Scaleform(string id, bool instanced = false, ScaleformType type = ScaleformType.Generic)
        {
            if (!this.Load(id, instanced))
                throw new ArgumentException($"No Scaleform movie with ID {id} was found.");

            this._type = type;
        }

        private bool Load(string id, bool instanced)
        {
            var handle = instanced
                ? Natives.Graphics.RequestScaleformMovieInstance(id)
                : Natives.Graphics.RequestScaleformMovie(id);

            if (handle == 0)
                return false;

            this._id = id;
            this._handle = handle;

            return true;
        }

        public void Unload()
        {
            if (!this.IsLoaded)
                return;
            
            Natives.Graphics.SetScaleformMovieAsNoLongerNeeded(_handle);
        }

        public bool IsLoaded => Natives.Graphics.HasScaleformMovieLoaded(_handle);

        protected void Initialize()
        {
            this.CallFunction("INITIALISE");
        }

        public void Debug()
        {
            this.CallFunction("debug");
        }

        public override void CallFunction(string function, params object[] parameters)
        {
            Natives.Graphics.PushScaleformMovieFunction(_handle, function);
            this.PushParameters(parameters);
            Natives.Graphics.PopScaleformMovieFunctionVoid();
        }

        public override bool CallFunctionBool(string function, params object[] parameters)
        {
            Natives.Graphics.PushScaleformMovieFunction(_handle, function);
            this.PushParameters(parameters);
            var returnHandle = Natives.Graphics.PopScaleformMovieFunction();
            return Natives.Graphics.GetScaleformMovieFunctionReturnBool(returnHandle);
        }
        
        public override int CallFunctionInt(string function, params object[] parameters)
        {
            Natives.Graphics.PushScaleformMovieFunction(_handle, function);
            this.PushParameters(parameters);
            var returnHandle = Natives.Graphics.PopScaleformMovieFunction();
            return Natives.Graphics.GetScaleformMovieFunctionReturnInt(returnHandle);
        }

        public void Draw(int red = 255, int green = 255, int blue = 255, int alpha = 255)
        {
            Natives.Graphics.DrawScaleformMovie2DFullscreen(_handle, red, green, blue, alpha);
        }
        public void Draw(float posX, float posY, float width, float height, 
            int red = 255, int green = 255, int blue = 255, int alpha = 255)
        {
            Natives.Graphics.DrawScaleformMovie2D(_handle, posX, posY, width, height, red, green, blue, alpha);
        }

        public void Draw3D(float posX, float posY, float posZ, 
            float rotX, float rotY, float rotZ, 
            float scaleX, float scaleY, float scaleZ, float sharpness = 1.0f)
        {
            Natives.Graphics.DrawScaleformMovie3D(_handle, posX, posY, posZ, rotX, rotY, rotZ, scaleX, scaleY, scaleZ, sharpness);
        }
        
        // Todo: Add Draw3D Additive method.
    }
    
    // Todo: Add Hud Scaleform class.
}