import React from 'react';

export function TradeData(props) {
    return <div>
        <p>Price: <strong>{props.price}</strong></p>
        <p>Percent Change: <strong>{props.percentChange}%</strong></p>
        </div>;
}