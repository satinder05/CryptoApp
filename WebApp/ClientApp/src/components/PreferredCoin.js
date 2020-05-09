import React, { Component } from 'react';
import { TradeData } from './TradeData';

export class PreferredCoin extends Component {
    constructor(props) {
        super(props);
        this.state = {
            preferredCoin: 1,
            isLoaded: false,
            tradeData: [],
            coinList:[]
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);

        this.getTradeData = this.getTradeData.bind(this);
        this.getPreferredCoin = this.getPreferredCoin.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.clearTradeData();
        this.savePreferredCoin(parseInt(this.state.preferredCoin))
    }

    componentWillMount() {
        this.getCoinList();
    }
        
    componentDidMount() {        
        this.getPreferredCoin();
        this.getTradeData();
    }

    
    render() {
        let tradeContent = !this.state.isLoaded
            ? <p><em>Loading...</em></p>
            : <TradeData price={this.state.tradeData.ask} percentChange={this.state.tradeData.askPriceChangePercent} />;
        return(
            <div>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <label>Preferred Coin</label>
                        <select style={{width:'13%'}} className="form-control" id="preferredCoin" name="preferredCoin" value={this.state.preferredCoin} onChange={this.handleChange}>
                            {
                                this.state.coinList.map((obj) => {
                                    return <option value={obj.id}>{obj.symbol}</option>
                                })
                            }
                        </select>
                        <input type="submit" value="Save Prefeference" />
                    </div>
                </form>
                <hr />
                {tradeContent}
            </div>
            );
    }

    async getPreferredCoin() {
        const response = await fetch('api/PreferredCoin');
        const data = await response.json();
        this.setState({ preferredCoin: data });
    }

    async getTradeData() {
        const response = await fetch('api/PreferredCoin/TradeData');
        const data = await response.json();
        this.setState({ tradeData: data, isLoaded: true });
    }

    async savePreferredCoin(preferredCoin) {
        let response = await fetch('api/PreferredCoin', {
            method: 'POST',
            headers: {
                "Content-type": "application/json charset=utf-8"
            },
            body: preferredCoin,
        });
        await response.json();
        this.getTradeData();
    }

    async getCoinList() {
        const response = await fetch('api/Coins');
        const data = await response.json();
        this.setState({ coinList: data });
    }

    clearTradeData() {
        this.setState({
            isLoaded: false
        });
    }
}