import { useEffect, useState } from 'react';
import { Button } from "react-bootstrap";
import './App.css';


interface CoffeeCup {
    coffeeId: number,
    createdDate: string;
}

interface CoffeeMachineStatus {
    coffeeMachineID: number,
    isOn: boolean,
    isMakingCoffee: boolean,
    waterLevelState: number,
    beanFeedState: number,
    wasteCoffeeState: number,
    waterTrayState: number
}

function App() {
    const [coffeeCups, setCoffeeCups] = useState<CoffeeCup[]>();
    const [coffeeMachineStatus, setCoffeeMachineStatus] = useState<CoffeeMachineStatus[]>();

    useEffect(() => {
        populateCoffeeCupsData();
        fetchCoffeeMachineStatus();
    }, []);

    

    const contents = coffeeCups === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel" align="center">
            <thead>
                <tr>
                    <th>Coffee Number</th>
                    <th>Date</th>                    
                </tr>
            </thead>
            <tbody>
                {coffeeCups.map(coffeeCups =>
                    <tr key={coffeeCups.coffeeId}>
                        <td>Coffee {coffeeCups.coffeeId}</td>
                        <td>{coffeeCups.createdDate}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    const IsInAlertState = coffeeMachineStatus === undefined ? "Loading" : (coffeeMachineStatus[0].waterLevelState == 0 && coffeeMachineStatus[0].beanFeedState == 0 && coffeeMachineStatus[0].wasteCoffeeState == 0 && coffeeMachineStatus[0].waterTrayState == 0) ? "Good" : "Alert";

    const status = coffeeMachineStatus === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel" background-color="white">
            <thead>
                <tr>
                    <th>Power</th>
                    <th>Alert State</th>
                    <th>Make Coffee</th>
                    <th>Water Level State</th>
                    <th>Bean Feed State</th>
                    <th>Waste Coffee State</th>
                    <th>Water Tray State</th>
                </tr>
            </thead>
            <tbody>                    
                <tr key={coffeeMachineStatus[0].coffeeMachineID}>                            
                    <td>
                        {coffeeMachineStatus[0].isOn == true ? "On" : "Off"}
                    </td>
                    <td>{IsInAlertState}</td>
                    <td>{coffeeMachineStatus[0].isMakingCoffee == true ? "Yes" : "No"}</td>                    
                    <td>{coffeeMachineStatus[0].waterLevelState == 0 ? "Good" : "Alert"}</td>
                    <td>{coffeeMachineStatus[0].beanFeedState == 0 ? "Good" : "Alert"}</td>
                    <td>{coffeeMachineStatus[0].wasteCoffeeState == 0 ? "Good" : "Alert"}</td>
                    <td>{coffeeMachineStatus[0].waterTrayState == 0 ? "Good" : "Alert"}</td>
                    </tr>                    
            </tbody>
        </table>;

    const MachinePowerButton = () => {

        const variant = (coffeeMachineStatus === undefined) ? 'secondary' : (IsInAlertState === 'Alert') ? 'warning' : ((coffeeMachineStatus[0].isOn) ? 'success' : 'danger')
        const content = (coffeeMachineStatus === undefined) ? 'Loading' : (IsInAlertState === 'Alert') ? 'Alert State' :  ((coffeeMachineStatus[0].isOn) ? 'Power On' : 'Power Off')
        const [buttonState, setButtonState] = useState({
            variant: variant ,
            content: content
        });

        const handleButtonClick = () => {
            if (coffeeMachineStatus != undefined) {
                if (IsInAlertState != 'Alert')
                {
                    SwitchPower();
                    const newContent = buttonState.content === 'Power On' ? 'Power Off' : 'Power On';
                    const newVariant = buttonState.variant === 'success' ? 'danger' : 'success'
                    setButtonState({
                        variant: newVariant,
                        content: newContent
                    });
                    window.location.reload();
                }                
            }
        };

        return (
            <Button 
                onClick={handleButtonClick}
                variant={buttonState.variant}
                className="m-4"> {buttonState.content}
            </Button>
        );
    }

    const MakeCofeeButton = () => {

        const variant = (coffeeMachineStatus === undefined || IsInAlertState === 'Alert') ? 'secondary' : 'primary'
        const content = (coffeeMachineStatus === undefined) ? 'Loading' : (IsInAlertState === 'Alert') ? 'Unavailable' : 'Make Coffee'        

        const handleButtonClick = () => {
            if (coffeeMachineStatus != undefined) {
                if (IsInAlertState != 'Alert' && coffeeMachineStatus[0].isOn) {
                    MakeCoffee();
                    window.location.reload();
                }
            }
        };

        return (
            <Button
                onClick={handleButtonClick}
                variant={variant}
                className="m-4"> {content}
            </Button>
        );
    }
        
    return (
        <div>
            <h1 id="tabelLabel">Smart Coffee Machine</h1>
            <div>
                <h3>Machine Status</h3>
                {status}
            </div>
            <div>
                <h3>Actions</h3>
                <MachinePowerButton />
                <MakeCofeeButton />
            </div>
            <div>
                <h3>Machine History</h3>
                {contents}
            </div>
            
        </div>
    );
     
    async function populateCoffeeCupsData() {
        const response = await fetch('CoffeeCup');
        const data = await response.json();
        setCoffeeCups(data);
    }

    async function fetchCoffeeMachineStatus() {
        const response = await fetch('CoffeeMachine');
        const data = await response.json();
        setCoffeeMachineStatus(data);
    }
    async function MakeCoffee() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title: 'Making Coffee' })
        };

        fetch('CoffeeCup', requestOptions)
            .then(response => {
                console.log(response);
            });
    }
    async function SwitchPower() {

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }
        };

        fetch('CoffeeMachine', requestOptions)
            .then(response => {
                console.log(response);
            });
    }
}

export default App;