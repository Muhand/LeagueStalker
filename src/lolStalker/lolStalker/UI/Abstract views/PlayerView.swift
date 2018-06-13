//
//  PlayerView.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/7/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

protocol PlayerViewDelegate {
    func didSetPlayer(player: Player, form: PlayerView)
    func cancelPressed(form: PlayerView)
}

class PlayerView: UIView {
    ////////////////////////////////////
    //            Delegates
    ////////////////////////////////////
    var delegate: PlayerViewDelegate?
    
    ////////////////////////////////////
    //Global Variables
    ////////////////////////////////////
    var player: Player? {
        didSet{
            
        }
    }
    
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let cancelBtn: UIButton = {
        let button = UIButton()
        button.setBackgroundColor(color: UIColor(hex: "#010A13")!, forState: .normal)
        button.setBackgroundColor(color: UIColor(hex: "#CE9340")!, forState: .highlighted)
        button.setTitleColor(UIColor(hex: "#CE9340"), for: .normal)
        button.setTitleColor(UIColor(hex: "#010A13"), for: .highlighted)
        button.setTitle("CANCEL", for: .normal)
        button.layer.borderWidth = Helper.getWidthOf(xdWidth: 1, referenceWidth: nil, originalWidth: nil)
        button.layer.borderColor = UIColor(hex: "#CE9340")?.cgColor
        button.titleLabel?.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 12, referenceHeight: nil, referenceWidth: nil))
        button.addTarget(self, action: #selector(cancelPressed), for: .touchUpInside)
        return button
    }()
    
    let rankImage: UIImageView = {
        let image = UIImageView()
        image.image = UIImage(named: "tempRank")
        image.contentMode = .scaleAspectFit
        image.layer.masksToBounds = true
        image.frame.size = CGSize(width: Helper.getWidthOf(xdWidth: 200, referenceWidth: nil, originalWidth: nil), height: Helper.getWidthOf(xdWidth: 200, referenceWidth: nil, originalWidth: nil))
        return image
    }()
    
    let rankTitle: UILabel = {
        let label = UILabel()
        label.text = "Master"
        label.textColor = UIColor(hex: "#95989A")
        if (UIDevice.current.userInterfaceIdiom == .pad) {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 40, referenceHeight: nil, referenceWidth: nil))
        } else {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        }
        label.text = label.text?.capitalized
        return label
    }()
    
    let minimalStatsView: UIView = {
        let view = UIView()
//        view.backgroundColor = .red
        return view
    }()
    
    let winRateProgressBar: UIView = {
        let view = UIView()
        view.backgroundColor = .green
        return view
    }()
    
    let roleProgressBar: UIView = {
        let view = UIView()
        view.backgroundColor = .blue
        return view
    }()
    
    let winRateLabel: UILabel = {
        let label = UILabel()
        label.text = "Win Rate"
        label.textColor = UIColor(hex: "#95989A")
        if (UIDevice.current.userInterfaceIdiom == .pad) {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 40, referenceHeight: nil, referenceWidth: nil))
        } else {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        }
        label.text = label.text?.capitalized
        return label
    }()
    
    let roleLabel: UILabel = {
        let label = UILabel()
        label.text = "Support"
        label.textColor = UIColor(hex: "#95989A")
        if (UIDevice.current.userInterfaceIdiom == .pad) {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 40, referenceHeight: nil, referenceWidth: nil))
        } else {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        }
        label.text = label.text?.capitalized
        return label
    }()
    
    let winLoseSeparator: UILabel = {
        let label = UILabel()
        label.text = "-"
        label.textColor = UIColor(hex: "#95989A")
        if (UIDevice.current.userInterfaceIdiom == .pad) {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 60, referenceHeight: nil, referenceWidth: nil))
        } else {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 40, referenceHeight: nil, referenceWidth: nil))
        }
        label.text = label.text?.capitalized
        return label
    }()
    
    let wins: UILabel = {
        let label = UILabel()
        label.text = "500W"
        label.textColor = UIColor(hex: "#00FF00")
        if (UIDevice.current.userInterfaceIdiom == .pad) {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 60, referenceHeight: nil, referenceWidth: nil))
        } else {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 40, referenceHeight: nil, referenceWidth: nil))
        }
        label.text = label.text?.capitalized
        return label
    }()
    
    let loses: UILabel = {
        let label = UILabel()
        label.text = "249L"
        label.textColor = UIColor(hex: "#FF0000")
        if (UIDevice.current.userInterfaceIdiom == .pad) {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 60, referenceHeight: nil, referenceWidth: nil))
        } else {
            label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 40, referenceHeight: nil, referenceWidth: nil))
        }
        label.text = label.text?.capitalized
        return label
    }()
    
    let runesSection: PlayerSection = {
        let section = PlayerSection()
        section.title = "Current Runes"
        return section
    }()
    
    let testView: UIView = {
        let view = UIView()
        view.backgroundColor = .purple
        let label: UILabel = {
            let lab = UILabel()
            lab.text = "TEST"
            return lab
        }()
        view.addSubview(label)
        label.translatesAutoresizingMaskIntoConstraints = false
        label.topAnchor.constraint(equalTo: view.topAnchor).isActive = true
        label.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        return view
    }()
    
    ////////// END OF CONTROLS /////////
    
    override init(frame: CGRect) {
        super.init(frame: frame)
        setupView()
        setupConstraints()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func setupView() {
        backgroundColor = UIColor(hex: "#010A13")
    }
    
    func setupConstraints() {
        // MARK: Add subviews
        addSubview(cancelBtn)
        addSubview(rankImage)
        addSubview(rankTitle)
        addSubview(minimalStatsView)
        minimalStatsView.addSubview(winRateProgressBar)
        minimalStatsView.addSubview(roleProgressBar)
        addSubview(winRateLabel)
        addSubview(roleLabel)
        addSubview(winLoseSeparator)
        addSubview(wins)
        addSubview(loses)
        addSubview(runesSection)
        runesSection.content = testView
        
        // MARK: Disable frames
        cancelBtn.translatesAutoresizingMaskIntoConstraints = false
        rankImage.translatesAutoresizingMaskIntoConstraints = false
        rankTitle.translatesAutoresizingMaskIntoConstraints = false
        minimalStatsView.translatesAutoresizingMaskIntoConstraints = false
        winRateProgressBar.translatesAutoresizingMaskIntoConstraints = false
        roleProgressBar.translatesAutoresizingMaskIntoConstraints = false
        winRateLabel.translatesAutoresizingMaskIntoConstraints = false
        roleLabel.translatesAutoresizingMaskIntoConstraints = false
        winLoseSeparator.translatesAutoresizingMaskIntoConstraints = false
        wins.translatesAutoresizingMaskIntoConstraints = false
        loses.translatesAutoresizingMaskIntoConstraints = false
        runesSection.translatesAutoresizingMaskIntoConstraints = false
        
        //////////////////////////////////
        // MARK: Constraints
        //////////////////////////////////
        cancelBtn.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 76, referenceWidth: nil, originalWidth: nil)).isActive = true
        cancelBtn.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 21.36, referenceHeight: nil, originalHeight: nil)).isActive = true
        cancelBtn.topAnchor.constraint(equalTo: topAnchor, constant: Helper.getHeightOf(xdHeight: 20, referenceHeight: nil, originalHeight: nil)).isActive = true
        cancelBtn.leftAnchor.constraint(equalTo: leftAnchor).isActive = true
        
        // RANK IMAGE
        rankImage.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 200, referenceWidth: nil, originalWidth: nil)).isActive = true
        rankImage.heightAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 200, referenceWidth: nil, originalWidth: nil)).isActive = true
        rankImage.topAnchor.constraint(equalTo: topAnchor, constant: 33).isActive = true
        rankImage.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        
        // RANK TITLE
        rankTitle.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        rankTitle.topAnchor.constraint(equalTo: rankImage.bottomAnchor).isActive = true
        
        // MINIMAL STATS (WIN RATE - MOST PLAYED ROLE
        minimalStatsView.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        minimalStatsView.topAnchor.constraint(equalTo: rankTitle.bottomAnchor, constant:20).isActive = true
        minimalStatsView.widthAnchor.constraint(equalToConstant: (Helper.getHeightOf(xdHeight: 117, referenceHeight: nil, originalHeight: nil)) * 2 + Helper.getWidthOf(xdWidth: 40, referenceWidth: nil, originalWidth: nil)).isActive = true
        minimalStatsView.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 117, referenceHeight: nil, originalHeight: nil)).isActive = true
        
        // WIN RATE PROGRESS BAR
        winRateProgressBar.leftAnchor.constraint(equalTo: minimalStatsView.leftAnchor).isActive = true
        winRateProgressBar.topAnchor.constraint(equalTo: minimalStatsView.topAnchor).isActive = true
        winRateProgressBar.widthAnchor.constraint(equalTo: minimalStatsView.heightAnchor).isActive = true
        winRateProgressBar.heightAnchor.constraint(equalTo: minimalStatsView.heightAnchor).isActive = true
        
        // ROLE PROGRESS BAR
        roleProgressBar.rightAnchor.constraint(equalTo: minimalStatsView.rightAnchor).isActive = true
        roleProgressBar.topAnchor.constraint(equalTo: minimalStatsView.topAnchor).isActive = true
        roleProgressBar.widthAnchor.constraint(equalTo: minimalStatsView.heightAnchor).isActive = true
        roleProgressBar.heightAnchor.constraint(equalTo: minimalStatsView.heightAnchor).isActive = true
        
        // Win rate label
        winRateLabel.topAnchor.constraint(equalTo: winRateProgressBar.bottomAnchor, constant:5).isActive = true
        winRateLabel.centerXAnchor.constraint(equalTo: winRateProgressBar.centerXAnchor).isActive = true
        
        // Role label
        roleLabel.topAnchor.constraint(equalTo: roleProgressBar.bottomAnchor, constant: 5).isActive = true
        roleLabel.centerXAnchor.constraint(equalTo: roleProgressBar.centerXAnchor).isActive = true
        
        // Wins/Lose
        winLoseSeparator.topAnchor.constraint(equalTo: winRateLabel.bottomAnchor, constant: 28).isActive = true
        winLoseSeparator.centerXAnchor.constraint(equalTo: minimalStatsView.centerXAnchor).isActive = true
        
        wins.topAnchor.constraint(equalTo: winLoseSeparator.topAnchor).isActive = true
        wins.rightAnchor.constraint(equalTo: winLoseSeparator.leftAnchor, constant: -10).isActive = true
        
        loses.topAnchor.constraint(equalTo: winLoseSeparator.topAnchor).isActive = true
        loses.leftAnchor.constraint(equalTo: winLoseSeparator.rightAnchor, constant: 10).isActive = true
        
        runesSection.topAnchor.constraint(equalTo: loses.bottomAnchor, constant: 35).isActive = true
        runesSection.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
//        runesSection.heightAnchor.constraint(equalToConstant: 800).isActive = true
        runesSection.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
    }
    
    @IBAction func cancelPressed(sender: AnyObject) {
        delegate?.cancelPressed(form: self)
    }
}
