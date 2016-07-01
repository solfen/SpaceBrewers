using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public static class ReflectionUtils {

    private static Dictionary<System.Type, Dictionary<string, FieldInfo>> fields = new Dictionary<System.Type, Dictionary<string, FieldInfo>>();
    private static System.Type[] modifiableTypes = { typeof(RessourcesManager), typeof(Sector), typeof(MercenaryTeam) };

    public static void Init() {
        for (int i = 0; i < modifiableTypes.Length; i++) {
            fields.Add(modifiableTypes[i], new Dictionary<string, FieldInfo>());
            SaveFieldsInDictionary(modifiableTypes[i]);
        }
    }

    public static bool CheckCondition<T>(T instance, FieldModificator fieldModificator) {
        if (fieldModificator.sign == ">")
            return ((float)fields[typeof(T)][fieldModificator.field].GetValue(instance) > fieldModificator.amount);

        else if (fieldModificator.sign == "<")
            return ((float)fields[typeof(T)][fieldModificator.field].GetValue(instance) < fieldModificator.amount);

        else {
            return ((float)fields[typeof(T)][fieldModificator.field].GetValue(instance) == fieldModificator.amount);
        }
    }

    public static void AddAmount<T>(T instance, string field, float amount) {
        fields[typeof(T)][field].SetValue(instance, (float)fields[typeof(T)][field].GetValue(instance) + amount);
    }

    public static float GenerateRandomFromRewardString(string randomReward) {
        if (randomReward == "") {
            Debug.LogError("Can't Generate Random, string is empty !");
            return 0f;
        }

        float amount;

        // string is of format : startRange-EndRange ex 150-200
        if (randomReward.Contains(",")) {
            string[] strRandomNb = randomReward.Split(',');
            amount = Random.Range(int.Parse(strRandomNb[0]), int.Parse(strRandomNb[1]));
        }
        else {
            amount = float.Parse(randomReward);
        }

        return amount;
    }

    private static void SaveFieldsInDictionary(System.Type type) {
        FieldInfo[] tmpFields = type.GetFields();
        for (int i = 0; i < tmpFields.Length; i++) {
            fields[type].Add(tmpFields[i].Name, tmpFields[i]);
        }
    }
}
