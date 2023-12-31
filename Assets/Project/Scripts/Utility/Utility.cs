using UnityEngine;
using System;
using System.Reflection;

namespace NewUtility{
    public static class Utility
    {

        /// <summary>
        /// Этот метод ориентирует объект относительно цели в 2D пространстве
        /// </summary>
        /// <param name="rollingTransform">Transform, который будет вращаться</param>
        /// <param name="targetTransform">Transform цели, на которую идёт вращение</param>
        public static void RotateObjectToTarget2D(Transform rollingTransform, Transform targetTransform)
        {
                Vector3 targ = targetTransform.position;
                targ.z = 0f;

                Vector3 objectPos = rollingTransform.position;
                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;

                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                rollingTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));    
        }

        /// <summary>
        /// Этот метод копирует объект (значение полей объекта)
        /// </summary>
        /// <param name="baseObject">Объект, с которого копируются поля</param>
        /// <param name="copyObject">Объект, куда копируется поля базового объекта</param>
        public static void CopyValues<T>(T baseObject, T copyObject)
        {
            Type type = baseObject.GetType();
            foreach(FieldInfo field in type.GetFields())
            {
                field.SetValue(copyObject, field.GetValue(baseObject));
            }
        }
    }
}