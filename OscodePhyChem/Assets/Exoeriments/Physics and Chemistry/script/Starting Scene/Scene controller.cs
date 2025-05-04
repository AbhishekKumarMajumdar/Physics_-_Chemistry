using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    #region UI/UX
    public void Startscene()
    {
        SceneManager.LoadScene("Starting Scene");
    }

    public void Class10()
    {
        SceneManager.LoadScene("Class_10_explist");
    }

    public void Class12()
    {
        SceneManager.LoadScene("Class_12_explist");
    }

    #endregion

    #region  Class 10
    public void ClassTenExpOneElectricCircuit()
    {
        SceneManager.LoadScene("Electric circuit exp 1");
    }
    public void ClassTenExpTwoSpringBalance()
    {
        SceneManager.LoadScene("SpringBalanceexp2");
    }
    public void ClassTenExpThreeStarchInLeaves()
    {
        SceneManager.LoadScene("Starch in leaves Experiment 3");
    }

    public void ClassTenExpFourPersentageOfOtwo()
    {
        SceneManager.LoadScene("percent of oxygen in air Experiment 4");
    }

    public void ClassTenExpFivePresenceOfCoTwo()
    {
        SceneManager.LoadScene("Presence of Co2 exp 11");
    }
    public void ClassTenExpSixPulsePropagation()
    {
        SceneManager.LoadScene("Pulse propagated Exp 7");
    }
    public void ClassTenExpSevenCarryOutReaction()
    {
        SceneManager.LoadScene("Carry out Exp 15");
    }

    #endregion

    #region class 12
    public void ClassTwelveExponeScrew()
    {
        SceneManager.LoadScene("exp 1 Screw gauge");
    }
    public void ClassTwelveExpTwoVernier()
    {
        SceneManager.LoadScene("exp 2 vernier callipers");
    }
    public void ClassTwelveExpThreeSpherometer()
    {
        SceneManager.LoadScene("exp 3 spherometer");
    }
    public void ClassTwelveExpFourPendulum()
    {
        SceneManager.LoadScene("exp 4 simple pendulum");
    }
    public void ClassTwelveExpFiveNewtonCool()
    {
        SceneManager.LoadScene("exp6 newtons law of cooling");
    }

    #endregion


}
